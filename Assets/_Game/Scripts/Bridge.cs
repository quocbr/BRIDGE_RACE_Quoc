using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject plank;
    [SerializeField] private Transform transformParent;

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        double lenght = this.transform.localScale.z;
        int plankCount = (int)Math.Round(lenght * 2) - 1;
        Debug.Log(plankCount/2);

        if (plankCount % 2 != 0)
        {

            Instantiate(plank,transformParent,true);
            int ck1 = 1,ck2=1;
            for(int i = 0; i < plankCount; i++)
            {
                GameObject newPlank = Instantiate(plank,transformParent,true);
                if(i%2 == 0)
                {
                    newPlank.transform.position += ck1*Vector3.forward;
                    ck1++;
                }
                else
                {
                    newPlank.transform.position += ck2 * Vector3.back;
                    ck2++;
                }
                
            }

        }
    }

}
