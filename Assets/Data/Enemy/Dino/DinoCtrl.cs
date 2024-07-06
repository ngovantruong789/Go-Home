using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCtrl : DinoLinked
{
    [SerializeField] protected bool isMove;
    [SerializeField] protected bool isShoot;
    [SerializeField] protected bool isDead;

    private void FixedUpdate()
    {
        Action();
    }

    protected void Action()
    {
        isDead = dinoDMR.IsDead;
        if (isDead) return;

        dinoShooting.CheckIsShooting();
        isMove = dinoMove.IsMove;
        isShoot = dinoShooting.IsShoot;

        if(isMove && !isDead) dinoStateController.ChangeState(new DinoMoveState(this));
        else if(isShoot && !isDead) dinoStateController.ChangeState(new DinoAttackState(this));
        else if(!isMove && !isDead) dinoStateController.ChangeState(new DinoIdleState(this));
    }
}
