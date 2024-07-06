using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackaHeadIdleState : IState
{
    JackaCtrl jackaCtrl;

    public JackaHeadIdleState(JackaCtrl jackaCtrl)
    {
        this.jackaCtrl = jackaCtrl;
    }

    public void Enter()
    {
        jackaCtrl.JackaAnimator.JackaHeadCtrl.HeadAnimator.SetTriggerParameter("Tr_Idle");
        Debug.Log("idle");
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
