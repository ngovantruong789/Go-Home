using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDLinked : TruongMonoBehaviour
{
    [SerializeField] protected DDMove dDMove;
    public DDMove DDMove => dDMove;

    [SerializeField] protected DungDropperDMR dungDropperDMR;
    public DungDropperDMR DungDropperDMR => dungDropperDMR;

    [SerializeField] protected DungDropperDMS dungDropperDMS;
    public DungDropperDMS DungDropperDMS => dungDropperDMS;

    [SerializeField] protected DDAttack dDAttack;
    public DDAttack DDAttack => dDAttack;

    [SerializeField] protected DDAnimator dDAnimator;
    public DDAnimator DDAnimator => dDAnimator;

    [SerializeField] protected DDDespawn dDDespawn;
    public DDDespawn DDDespawn => dDDespawn;

    [SerializeField] protected DDStateController dDStateController;
    public DDStateController DDStateController => dDStateController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDDStateController();
        LoadDDMove();
        LoadDDAttack();
        this.LoadDungDropperDMR();
        this.LoadDungDropperDMS();
        this.LoadDDAnimator();
        this.LoadDDDespawn();
    }

    protected virtual void LoadDDMove()
    {
        if (this.dDMove != null) return;
        this.dDMove = transform.GetComponentInChildren<DDMove>();
        Debug.LogWarning(transform.name + ": LoadDDMove", gameObject);
    }

    protected virtual void LoadDungDropperDMR()
    {
        if (this.dungDropperDMR != null) return;
        this.dungDropperDMR = transform.GetComponentInChildren<DungDropperDMR>();
        Debug.LogWarning(transform.name + ": LoadDungDropperDMR", gameObject);
    }
    protected virtual void LoadDungDropperDMS()
    {
        if (this.dungDropperDMS != null) return;
        this.dungDropperDMS = transform.GetComponentInChildren<DungDropperDMS>();
        Debug.LogWarning(transform.name + ": LoadDungDropperDMS", gameObject);
    }

    protected virtual void LoadDDAnimator()
    {
        if (this.dDAnimator != null) return;
        this.dDAnimator = transform.GetComponentInChildren<DDAnimator>();
        Debug.LogWarning(transform.name + ": LoadDDAnimator", gameObject);
    }

    protected virtual void LoadDDAttack()
    {
        if (this.dDAttack != null) return;
        this.dDAttack = transform.GetComponentInChildren<DDAttack>();
        Debug.LogWarning(transform.name + ": LoadDDAttack", gameObject);
    }

    protected virtual void LoadDDDespawn()
    {
        if (this.dDDespawn != null) return;
        this.dDDespawn = transform.GetComponentInChildren<DDDespawn>();
        Debug.LogWarning(transform.name + ": LoadDDDespawn", gameObject);
    }

    protected virtual void LoadDDStateController()
    {
        if (this.dDStateController != null) return;
        this.dDStateController = transform.GetComponent<DDStateController>();
        Debug.LogWarning(transform.name + ": LoadDDStateController", gameObject);
    }
}
