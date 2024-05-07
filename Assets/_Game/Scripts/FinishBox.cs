using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBox : MonoBehaviour
{
    [SerializeField]private List<Transform> list;

    private int currentST = 0;

    public Vector3 GetTranf()
    {
        return list[currentST-1].transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        currentST++;
    }

}
