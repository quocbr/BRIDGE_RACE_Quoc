using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        t.StopMoving();
        
    }

    public void OnExecute(Bot t)
    {
        if (GameManager.Ins.IsStart)
        {
            t.ChangeState(new FindState());
        }
    }

    public void OnExit(Bot t)
    {

    }

}
