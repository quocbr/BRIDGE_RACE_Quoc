using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bot : Character
{
    public Transform targetBrick;
    private NavMeshAgent agent;
    float nearDis = float.MaxValue;
    float distance;
    Brick nearBrick;

    private IState<Bot> currentState;

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }
    protected override void Start()
    {
        base.Start();
        ChangeState(new IdleState());
    }

    protected  void Update()
    {
        if (isWin)
        {
            return;
        }
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    protected override void OnInit()
    {
        base.OnInit();
        targetBrick = LevelManager.Ins.currentFinishPoint.transform;
    }

    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public void StopMoving()
    {
        ChangeAnim("idle");
        agent.isStopped = true;
    }

    public void Moving() 
    {
        ChangeAnim("run");
        agent.isStopped = false;
    }

    public void FindBrick()
    {
        
        List<Brick> bricks = FloorManager.Ins.GetBricks(CurrentFloor, ColorType);

        for (int i = 0; i < bricks.Count; i++)
        {
            distance = Vector3.Distance(this.transform.position, bricks[i].transform.position);
            if(distance < nearDis)
            {
                nearDis = distance;
                nearBrick = bricks[i];
            }
        }
        agent.destination = nearBrick.gameObject.transform.position;
        nearDis = float.MaxValue;

    }

    public void GoFinish()
    {
        agent.SetDestination(targetBrick.gameObject.transform.position);

    }

    public bool IsFinsh()
    {
        return Vector3.Distance(transform.position, targetBrick.transform.position) < 0.1f;
    }
}
