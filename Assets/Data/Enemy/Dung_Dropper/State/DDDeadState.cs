using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDDeadState : IState
{
    DDCtrl dDCtrl;

    public DDDeadState(DDCtrl dDCtrl)
    {
        this.dDCtrl = dDCtrl;
    }

    public void Enter()
    {
        dDCtrl.DDMove.SetMoveDirection(Vector3.up);
        dDCtrl.DDMove.isStop = false;
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
