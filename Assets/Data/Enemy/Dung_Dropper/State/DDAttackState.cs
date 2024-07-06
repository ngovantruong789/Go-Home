using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDAttackState : IState
{
    DDCtrl dDCtrl;

    public DDAttackState(DDCtrl dDCtrl)
    {
        this.dDCtrl = dDCtrl;
    }

    public void Enter()
    {
        dDCtrl.StartCoroutine(dDCtrl.DDAttack.Attack());
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
