using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : TruongMonoBehaviour
{
    [SerializeField] protected ThornCtrl thornCtrl;
    public ThornCtrl ThornCtrl => thornCtrl;

    [SerializeField] protected float speed = 5;
    public float Speed { get => speed; set => speed = value; }
    [SerializeField] protected Vector3 moveLeft = Vector3.left;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadThornCtrl();
    }

    protected virtual void FixedUpdate() {
        this.Move();
    }

    protected virtual void LoadThornCtrl()
    {
        if (this.thornCtrl != null) return;
        this.thornCtrl = transform.GetComponentInParent<ThornCtrl>();
        Debug.LogWarning(transform.name + ": LoadThornCtrl", gameObject);
    }

    protected virtual void Move(){
        transform.parent.Translate(this.moveLeft * this.Speed * Time.fixedDeltaTime);
    }
}
