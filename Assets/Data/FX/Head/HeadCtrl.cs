using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCtrl : TruongMonoBehaviour
{
    [SerializeField] protected HeadDespawn headDespawn;
    public HeadDespawn HeadDespawn => headDespawn;

    [SerializeField] protected HeadAttack headAttack;
    public HeadAttack HeadAttack => headAttack;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeadDespawn();
        LoadHeadAttack();
    }

    protected virtual void LoadHeadDespawn()
    {
        if (this.headDespawn != null) return;
        this.headDespawn = transform.GetComponentInChildren<HeadDespawn>();
        Debug.LogWarning(transform.name + ": LoadHeadDespawn", gameObject);
    }

    protected virtual void LoadHeadAttack()
    {
        if (this.headAttack != null) return;
        this.headAttack = transform.GetComponentInChildren<HeadAttack>();
        Debug.LogWarning(transform.name + ": LoadHeadAttack", gameObject);
    }
}
