using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCtrl : TruongMonoBehaviour
{
    [SerializeField] protected GroundDMS groundDMS;
    public GroundDMS GroundDMS => groundDMS;
    [SerializeField] protected GroundDespawn groundDespawn;
    public GroundDespawn GroundDespawn => groundDespawn;
    [SerializeField] protected GroundAnimator groundAnimator;
    public GroundAnimator GroundAnimator => groundAnimator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGroundDMS();
        this.LoadGroundDespawn();
        this.LoadGroundAnimator(); 
    }

    protected virtual void LoadGroundDMS()
    {
        if (this.groundDMS != null) return;
        this.groundDMS = transform.GetComponentInChildren<GroundDMS>();
        Debug.LogWarning(transform.name + ": LoadGroundDMS", gameObject);
    }
    protected virtual void LoadGroundDespawn()
    {
        if (this.groundDespawn != null) return;
        this.groundDespawn = transform.GetComponentInChildren<GroundDespawn>();
        Debug.LogWarning(transform.name + ": LoadGroundDespawn", gameObject);
    }

    protected virtual void LoadGroundAnimator()
    {
        if (this.groundAnimator != null) return;
        this.groundAnimator = transform.GetComponentInChildren<GroundAnimator>();
        Debug.LogWarning(transform.name + ": LoadGroundAnimator", gameObject);
    }

    public void ResetParent()
    {
        transform.SetParent(AttackSpawner.Instance.Holder);
    }
}
