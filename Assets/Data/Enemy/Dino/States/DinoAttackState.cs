using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAttackState : IState
{
    DinoCtrl dinoCtrl;
    public DinoAttackState(DinoCtrl dinoCtrl)
    {
        this.dinoCtrl = dinoCtrl;
    }

    public void Enter()
    {
        dinoCtrl.DinoAnimator.SetActiveEyes(false);
        dinoCtrl.DinoAnimator.SetTriggerParameter("Tr_Attack");
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
