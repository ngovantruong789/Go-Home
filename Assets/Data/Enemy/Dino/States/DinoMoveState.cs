using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMoveState : IState
{
    DinoCtrl dinoCtrl;
    public DinoMoveState(DinoCtrl dinoCtrl)
    {
        this.dinoCtrl = dinoCtrl;
    }

    public void Enter()
    {
        
    }

    public void Execute()
    {
        dinoCtrl.DinoMove.Moving();
    }

    public void Exit()
    {
        
    }
}
