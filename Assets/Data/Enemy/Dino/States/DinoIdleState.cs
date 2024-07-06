using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoIdleState : IState
{
    DinoCtrl dinoCtrl;
    public DinoIdleState(DinoCtrl dinoCtrl)
    {
        this.dinoCtrl = dinoCtrl;
    }

    public void Enter()
    {
        dinoCtrl.DinoAnimator.SetActiveEyes(true);
        dinoCtrl.DinoAnimator.SetTriggerParameter("Tr_Idle");
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
