using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMovement : TruongMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    [SerializeField] protected float speed = 3f;
    [SerializeField] protected Vector3 oldPosition;
    [SerializeField] protected Vector3 moveLeft = Vector3.left;
    [SerializeField] protected float distance = -10f;
    [SerializeField] protected bool isStop;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected override void Awake()
    {
        base.Start();
        this.OldPos();
    }

    protected virtual void FixedUpdate() {
        if (isStop) return;
        this.Move();
        this.ResetPos();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = Transform.FindObjectOfType<EnemyCtrl>();
        Debug.LogWarning(transform.name + "LoadEnemyCtrl", gameObject);
    }

    protected virtual void OldPos(){
        this.oldPosition = transform.parent.position;
    }

    protected virtual void Move(){
        transform.parent.Translate(this.moveLeft * this.speed * Time.fixedDeltaTime);
    }

    protected virtual void ResetPos(){
        if(this.transform.parent.position.x <= this.distance)
            this.transform.parent.position = this.oldPosition;
    }

    public void SetIsStop(bool isStop)
    {
        this.isStop = isStop;
    }
}
