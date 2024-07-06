using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JackaMove : TruongMonoBehaviour
{
    [SerializeField] protected JackaCtrl bossCtrl;
    [SerializeField] protected float speed = 0f;

    [SerializeField] protected Vector3 objMove = Vector3.left;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeLimit = 0f;
    [SerializeField] protected bool isMove = true;
    public bool IsMove => isMove;

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetValue();
        timer = timeLimit;
    }

    protected override void Start()
    {
        base.Start();
        timer = timeLimit;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossCtrl();
    }


    protected virtual void LoadBossCtrl()
    {
        if (this.bossCtrl != null) return;
        this.bossCtrl = transform.GetComponentInParent<JackaCtrl>();
        Debug.LogWarning(transform.name + ": LoadBossCtrl", gameObject);
    }

    public void Moving()
    {
        if (!isMove) return;
        this.timer -= Time.fixedDeltaTime;
        if (this.timer <= 0) isMove = false;
        transform.parent.Translate(this.objMove * this.speed * Time.fixedDeltaTime);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        isMove = true;
    }
}
