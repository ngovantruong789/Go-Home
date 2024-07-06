using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackaHeadAttackState : IState
{
    JackaCtrl jackaCtrl;

    public JackaHeadAttackState( JackaCtrl jackaCtrl)
    {
        this.jackaCtrl = jackaCtrl;
    }

    public void Enter()
    {
        jackaCtrl.JackaAnimator.JackaHeadCtrl.HeadAnimator.SetTriggerParameter("Tr_Attack1");
        jackaCtrl.StartCoroutine(jackaCtrl.JackaAttack.HeadAttack());
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
