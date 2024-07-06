using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackaIdleState : IState
{
    JackaCtrl jackaCtrl;

    public JackaIdleState(JackaCtrl jackaCtrl)
    {
        this.jackaCtrl = jackaCtrl;
    }

    public void Enter()
    {
        jackaCtrl.JackaAnimator.SetTriggerParameter("Tr_Idle");
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
