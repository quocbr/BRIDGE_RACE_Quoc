using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    [Header("Player")]
    [SerializeField]private VariableJoystick joystick;
    
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Canvas inputCanvas;

    private Transform tF;


    public bool isJoystick;

    protected override void OnInit()
    {
        base.OnInit();
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }

    protected void Update()
    {
        if(isWin)
        {
            return;
        }

        if (isJoystick) 
        { 
            var momentDirection = new Vector3(joystick.Direction.x,0,joystick.Direction.y);
            
            if(momentDirection.sqrMagnitude <= 0.01f) 
            {
                ChangeAnim(Anim.IDLE);
                return;
            }
            else
            {
                GameManager.Ins.IsStart = true;
                ChangeAnim(Anim.RUN);
            }

            this.Move(momentDirection.normalized);
        }

    }


    protected override void Move(Vector3 dir)
    {
        base.Move(dir);
        if (base.speed == 0)
        {
            if (this.isBack())
            {
                base.speed = 5;
            }
        }
        //base.controller.SimpleMove(dir * base.speed);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed*Time.deltaTime);
        var targetDirection = Vector3.RotateTowards(this.transform.forward, dir, rotationSpeed * Time.deltaTime, 0.0f);
        this.transform.rotation = Quaternion.LookRotation(targetDirection);
    }

    protected override void HandlleWin(GameObject trigger)
    {
        base.HandlleWin(trigger);
        UIManagerT.Ins.ShowWin();
    }
}
