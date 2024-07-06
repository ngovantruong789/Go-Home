using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DDMove : TruongMonoBehaviour
{
    [SerializeField] protected float speedMove = 1f;
    public float SpeedMove => speedMove;
    [SerializeField] protected float speedMoveMax = 1f;
    [SerializeField] protected Vector3 moveDirection = Vector3.down;
    [SerializeField] protected DDCtrl dDCtrl;
    [SerializeField] protected float timerMove;
    [SerializeField] protected float timerMoveMax;

    [SerializeField] protected float timerDespawn;
    [SerializeField] protected float timerDespawnMax;
    public float TimerDespawnMax => timerDespawnMax;
    public bool isStop;

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetValue();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDDCtrl();
    }

    protected virtual void LoadDDCtrl()
    {
        if (this.dDCtrl != null) return;
        this.dDCtrl = transform.GetComponentInParent<DDCtrl>();
        Debug.Log(transform.name + ": LoadDDCtrl", gameObject);
    }

    public virtual void Moving()
    {
        transform.parent.Translate(this.speedMove * moveDirection * Time.fixedDeltaTime);
    }

    public void DetuctTimerMove()
    {
        if (isStop) return;

        timerMove -= Time.fixedDeltaTime;
        if (timerMove > 0) return;
        isStop = true;
    }

    public void DetucTimerDespawn()
    {
        timerDespawn -= Time.fixedDeltaTime;
        if (timerDespawn > 0) return;

        dDCtrl.DDDespawn.DespawnObject();
    }

    public void SetMoveDirection(Vector3 direction)
    {
        moveDirection = direction;
    }

    public void SetSpeedMove(float speed)
    {
        speedMove = speed;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        moveDirection = Vector3.down;
        timerMove = timerMoveMax;
        timerDespawn = timerDespawnMax;
        speedMove = speedMoveMax;
    }
}
