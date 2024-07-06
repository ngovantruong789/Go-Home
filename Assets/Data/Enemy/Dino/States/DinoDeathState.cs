using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoDeathState : IState
{
    DinoCtrl dinoCtrl;
    public DinoDeathState(DinoCtrl dinoCtrl)
    {
        this.dinoCtrl = dinoCtrl;
    }

    public void Enter()
    {
        dinoCtrl.DinoAnimator.SetActiveEyes(false);
        dinoCtrl.DinoAnimator.SetTriggerParameter("Tr_Dead");
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
