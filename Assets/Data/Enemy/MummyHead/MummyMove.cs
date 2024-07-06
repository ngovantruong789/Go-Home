using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyMove : TruongMonoBehaviour
{
    [SerializeField] protected float speed = 5;
    public float Speed { get => speed; set => speed = value; }

    [SerializeField] protected Vector3 moveLeft = Vector3.left;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected virtual void FixedUpdate()
    {
        this.Move();
    }

    protected virtual void Move()
    {
        transform.parent.Translate(this.moveLeft * this.speed * Time.fixedDeltaTime);
    }
}
