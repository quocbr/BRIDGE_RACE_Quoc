using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Charracter")]
    [SerializeField] private ColorType colorType;
    //[SerializeField] private GameObject cBrick;
    [SerializeField] protected float speed;
    [SerializeField] private Animator anim;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;

    private GameObject cBrick;
    private int currentFloor;
    private string currentAnimName;
    protected bool isWin;
    protected Stack<GameObject> stackCBrick;

    public int CurrentFloor { get => currentFloor; set => currentFloor = value; }
    public ColorType ColorType { get => colorType; set => colorType = value; }

    protected virtual void Awake()
    {
        stackCBrick = new Stack<GameObject>();
    }

    protected virtual void Start()
    {
        OnInit();
    }

    protected virtual void OnInit()
    {
        CurrentFloor = 0;
        isWin = false;
        //stackCBrick = new Stack<GameObject>();
    }

    public virtual void ChangeColorType(ColorType colorType, GameObject brick)
    {
        this.colorType = colorType;
        skinnedMeshRenderer.material = FloorManager.Ins.GetMaterial(colorType);
        cBrick = brick;
    }

    protected virtual void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }

    protected virtual void Move(Vector3 dir)
    {
        
    }

    protected virtual void AddBrick()
    {
        GameObject newCBrick = Instantiate(cBrick);
        if (newCBrick != null)
        {
            stackCBrick.Push(newCBrick);
            newCBrick.transform.position += new Vector3(0, 0.3f * stackCBrick.Count, 0);

            newCBrick.transform.SetParent(transform, false);
        }

    }
    protected virtual void RemoveBrick() 
    {
        GameObject dCBrick = stackCBrick.Peek();
        stackCBrick.Pop();
        Destroy(dCBrick);
    }

    protected virtual void ClearBrick() 
    {
        while(stackCBrick.Count > 0)
        {
            GameObject dCBrick = stackCBrick.Peek();
            stackCBrick.Pop();
            Destroy(dCBrick);
        }
    }


    public bool isBack()
    {
        return transform.forward.z < 0;
    }

    protected virtual void HandleEat(GameObject trigger)
    {
        ColorType colorTrigger = trigger.GetComponent<Brick>().GetColorType();
        if (colorTrigger == colorType)
        {
            AddBrick();
        }
    }
    
    protected virtual void HandlleBridge(GameObject trigger)
    {
        ColorType colorTrigger = trigger.GetComponent<Plank>().GetColorType();
        
        
        if (colorTrigger == colorType || transform.forward.z < 0)
        {
            return;
        }

        if (checkStack() == 0) 
        {
            speed = 0;
            
            return; 
        }

        trigger.GetComponent<Plank>().SetColorType(colorType);
        trigger.GetComponent<Plank>().Test(checkStack() != 0);

        this.RemoveBrick();
    }

    protected virtual void HandlleWin(GameObject trigger)
    { 
        ClearBrick();
        isWin = true;
        this.transform.position = trigger.GetComponent<FinishBox>().GetTranf();
        ChangeAnim(Anim.WIN);
    }

    public int checkStack()
    {
        return stackCBrick.Count;
    }

    public virtual ColorType GetColorType() { return colorType; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Layer.BRICK)
        {
            HandleEat(other.gameObject);
            
        }
        if(other.gameObject.layer == Layer.BRIDGE)
        {

            HandlleBridge(other.gameObject);
        }
        if (other.gameObject.layer == Layer.FINISHBOX)
        {

            HandlleWin(other.gameObject);
        }
    }
}
