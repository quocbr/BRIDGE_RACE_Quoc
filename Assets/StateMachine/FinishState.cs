using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
       t.GoFinish();
    }

    public void OnExecute(Bot t)
    {
        if (t.checkStack() == 0)
        {
            t.ChangeState(new FindState());
        }

        if (t.IsFinsh())
        {
            t.ChangeState(new IdleState());
        }
    }

    public void OnExit(Bot t)
    {
        
    }
}
