using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAttack : TruongMonoBehaviour
{
    [SerializeField] protected HeadCtrl headCtrl;

    [SerializeField] protected Vector3 startPos;
    [SerializeField] protected Vector3 direction;
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeLimit = 0f;
    [SerializeField] protected float speed;
    [SerializeField] protected float speedMax;
    [SerializeField] protected float speedDetuct;
    [SerializeField] protected bool isBack;
    public bool IsBack => isBack;

    protected override void OnEnable()
    {
        base.OnEnable();
        LoadTargetPos();
        timer = timeLimit;
        speed = speedMax;
        startPos = transform.parent.position;
        SetDirection(targetPos, transform.parent.position);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        ResetValue();
    }

    private void FixedUpdate()
    {
        AttackFly();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeadCtrl();
    }

    protected virtual void LoadTargetPos()
    {
        this.targetPos = FindObjectOfType<CharacterImpact>().transform.position;
        Debug.LogWarning(transform.name + ": LoadTargetPos", gameObject);
    }

    protected virtual void LoadHeadCtrl()
    {
        if (this.headCtrl != null) return;
        this.headCtrl = transform.GetComponentInParent<HeadCtrl>();
        Debug.LogWarning(transform.name + ": LoadHeadCtrl", gameObject);
    }

    protected void AttackFly()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0 && !isBack)
        {
            speed -= speedDetuct;
            SetDirection(startPos, transform.parent.position);
            isBack = true;
        }
        transform.parent.Translate(direction * speed * Time.fixedDeltaTime);
    }

    protected void SetDirection(Vector3 target, Vector3 tranform)
    {
        this.direction = target - tranform;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        isBack = false;
    }
}
