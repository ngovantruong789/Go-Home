using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMove : TruongMonoBehaviour
{
    [SerializeField] protected Vector3 moveLeft = Vector3.left;
    [SerializeField] protected float timer;
    [SerializeField] protected float timerMax;
    [SerializeField] protected float speed = 5;

    public float Speed => speed;

    [SerializeField] protected bool isMove = true;
    public bool IsMove => isMove;

    protected override void OnDisable()
    {
        base.OnDisable();
        timer = timerMax;
        isMove = true;
    }

    public virtual void Moving()
    {
        timer -= Time.fixedDeltaTime;
        if(timer <= 0)
            isMove = false;
        if (!isMove) return;
        transform.parent.Translate(this.moveLeft * this.Speed * Time.fixedDeltaTime);
    }

    public bool GetIsMove()
    {
        return isMove;
    }
}
