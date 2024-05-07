using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : GameUnit
{
    [SerializeField] ColorType colorType;
    [SerializeField] MeshRenderer meshRenderer;

    public ColorType GetColorType() { return colorType; }
    public void SetColorType(ColorType type)
    {
        this.colorType = type;
        meshRenderer.material = FloorManager.Ins.GetMaterial(type);
    }

    private void HideAndShowBrick(float delay)
    {
        gameObject.SetActive(false);
        InvokeRepeating(nameof(ShowBrick), delay, 0.0f);
    }

    private void ShowBrick()
    {
        CancelInvoke(nameof(ShowBrick));
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (colorType == other.gameObject.GetComponent<Character>().GetColorType())
        {
            //gameObject.SetActive(false);
            float delay = Random.Range(3f, 7f);
            HideAndShowBrick(delay);
        }
        
    }
}
