using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureCtrl : TruongMonoBehaviour
{
    [SerializeField] protected VultureDMR vultureDMR;
    public VultureDMR VultureDMR => vultureDMR;

    [SerializeField] protected VultureDMS vultureDMS;
    public VultureDMS VultureDMS => vultureDMS;

    [SerializeField] protected VultureMove vultureMove;
    public VultureMove VultureMove => vultureMove;

    [SerializeField] protected VultureDespawn vultureDespawn;
    public VultureDespawn VultureDespawn => vultureDespawn;

    [SerializeField] protected VultureAnimator vultureAnimator;
    public VultureAnimator VultureAnimator => vultureAnimator;

    [SerializeField] protected CharacterCtrl characterCtrl;
    public CharacterCtrl CharacterCtrl => characterCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadVultureDMR();
        this.LoadVultureDMS();
        this.LoadVultureMove();
        this.LoadVultureDespawn();
        this.LoadVultureAnimator();
        this.LoadCharacterCtrl();
    }
    protected virtual void LoadVultureDMR()
    {
        if (this.vultureDMR != null) return;
        this.vultureDMR = transform.GetComponentInChildren<VultureDMR>();
        Debug.LogWarning(transform.name + ": LoadVultureDMR", gameObject);
    }

    protected virtual void LoadVultureDMS()
    {
        if (this.vultureDMS != null) return;
        this.vultureDMS = transform.GetComponentInChildren<VultureDMS>();
        Debug.LogWarning(transform.name + ": LoadVultureDMS", gameObject);
    }

    protected virtual void LoadVultureMove()
    {
        if (this.vultureMove != null) return;
        this.vultureMove = transform.GetComponentInChildren<VultureMove>();
        Debug.LogWarning(transform.name + ": LoadVultureMove", gameObject);
    }

    protected virtual void LoadVultureDespawn()
    {
        if (this.vultureDespawn != null) return;
        this.vultureDespawn = transform.GetComponentInChildren<VultureDespawn>();
        Debug.LogWarning(transform.name + ": LoadVultureDespawn", gameObject);
    }

    protected virtual void LoadVultureAnimator()
    {
        if (this.vultureAnimator != null) return;
        this.vultureAnimator = transform.GetComponentInChildren<VultureAnimator>();
        Debug.LogWarning(transform.name + ": LoadVultureAnimator", gameObject);
    }

    protected virtual void LoadCharacterCtrl()
    {
        if (this.characterCtrl != null) return;
        this.characterCtrl = Transform.FindObjectOfType<CharacterCtrl>();
        Debug.LogWarning(transform.name + ": LoadCharacterCtrl", gameObject);
    }
}
