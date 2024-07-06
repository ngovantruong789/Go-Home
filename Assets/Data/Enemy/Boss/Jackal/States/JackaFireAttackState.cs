using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackaFireAttackState : IState
{
    JackaCtrl jackaCtrl;

    public JackaFireAttackState(JackaCtrl jackaCtrl)
    {
        this.jackaCtrl = jackaCtrl;
    }

    public void Enter()
    {
        jackaCtrl.JackaAnimator.JackaHeadCtrl.HeadAnimator.SetTriggerParameter("Tr_Attack2");
        jackaCtrl.StartCoroutine(jackaCtrl.JackaAttack.FireAttack());
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
