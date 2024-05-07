using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FindState : IState<Bot>
{
    public int maxBrick;
    public void OnEnter(Bot t)
    {
        t.Moving();
        maxBrick = Random.Range(5, 10);
        
    }

    public void OnExecute(Bot t)
    {
        t.FindBrick();
        
        if(t.checkStack() == maxBrick)
        {
            t.ChangeState(new FinishState());
        }
        
    }

    public void OnExit(Bot t)
    {
        
    }
}
