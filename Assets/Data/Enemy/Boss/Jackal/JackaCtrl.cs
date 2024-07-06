using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackaCtrl : JackaLinked
{
    [SerializeField] protected bool isMove;
    [SerializeField] protected bool isAttack;

    private void FixedUpdate()
    {
        PlayAction();
    }

    protected void PlayAction()
    {
        GetAttack();
        GetMove();
        if (isAttack) return;
        else if(isMove)
        {
            jackaState.ChangeState(new JackaWalkState(this));
            jackaMove.Moving();
        }
        else
        {
            //hai cái chuyên qua lại liên tục
            jackaAnimator.JackaHeadCtrl.JackaHeadState.ChangeState(new JackaHeadIdleState(this));
            jackaState.ChangeState(new JackaIdleState(this));
        }
    }

    protected void GetMove()
    {
        isMove = jackaMove.IsMove;
    }

    protected void GetAttack()
    {
        jackaAttack.OnAttack();
        isAttack = jackaAttack.IsAttack;
    }
}
