using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    [SerializeField] ColorType colorType;
    [SerializeField] MeshRenderer meshRenderer;

    private void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        colorType = ColorType.None;
    }
    public ColorType GetColorType() { return colorType; }
    public void SetColorType(ColorType type)
    {
        this.colorType = type;
        meshRenderer.material = FloorManager.Ins.GetMaterial(type);
    }

    public void Test(bool isStack)
    {
        if (this.GetComponent<MeshRenderer>().enabled == false)
        {
            if (isStack)
            {
                this.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
    //bo
    private void OnCollisionEnter(Collision collision)
    {
        if (this.GetComponent<MeshRenderer>().enabled == false)
        {
            if (collision.gameObject.GetComponent<Character>().checkStack() != 0)
            {
                this.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }

}
