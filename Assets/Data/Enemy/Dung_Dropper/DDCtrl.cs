using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDCtrl : DDLinked
{
    [SerializeField] protected bool isStop;
    [SerializeField] protected bool isAttack;

    private void FixedUpdate()
    {
        PlayAction();
    }

    protected void PlayAction()
    {
        GetDataAttack();
        GetDataMove();

        
        if (isAttack || CheckDead())
        {
            dDStateController.ChangeState(new DDDeadState(this));
            dDMove.DetucTimerDespawn();
        }
        else if (!isAttack) dDMove.DetuctTimerMove();

        if (isStop) dDStateController.ChangeState(new DDAttackState(this));
        else dDMove.Moving();
    }

    protected void GetDataMove()
    {
        isStop = dDMove.isStop;
        
    }
    protected void GetDataAttack()
    {
        isAttack = dDAttack.IsAttack;
    }

    protected bool CheckDead()
    {
        return dungDropperDMR.IsDead;
    }
}
