using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject D1;
    [SerializeField] private GameObject D2;

    private void OnCollisionEnter(Collision collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();

        if ((collision.gameObject.layer == Layer.PLAYER || collision.gameObject.layer == Layer.BOT) && !character.isBack())
        {
            D1.SetActive(false);
            D2.SetActive(false);
            this.GetComponent<Collider>().isTrigger = true;

            FloorManager.Ins.SpawnBrickInFloor(character.CurrentFloor, character.GetColorType());
            character.CurrentFloor++;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Layer.PLAYER || other.gameObject.layer == Layer.BOT)
        { 
            this.GetComponent<Collider>().isTrigger = false;
        }
            
    }
}
