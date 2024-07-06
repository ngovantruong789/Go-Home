using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureAnimator : TruongMonoBehaviour
{
    [SerializeField] protected VultureCtrl vultureCtrl;
    public VultureCtrl VultureCtrl => vultureCtrl;

    [SerializeField] protected Transform modelIdlde;
    [SerializeField] protected Transform modelAtk;
    [SerializeField] protected Transform modelDead;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Disable();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadVultureCtrl();
        this.LoadModelIdle();
        this.LoadModelAtk();
        this.LoadModelDead();
    }

    protected virtual void LoadVultureCtrl()
    {
        if (this.vultureCtrl != null) return;
        this.vultureCtrl = transform.GetComponentInParent<VultureCtrl>();
        Debug.LogWarning(transform.name + ": LoadVultureCtrl", gameObject);
    }

    protected virtual void LoadModelIdle()
    {
        if (this.modelIdlde != null) return;
        this.modelIdlde = transform.Find("ModelIdle");
        Debug.LogWarning(transform.name + ": LoadModelIdle", gameObject);
    }

    protected virtual void LoadModelAtk()
    {
        if (this.modelAtk != null) return;
        this.modelAtk = transform.Find("ModelAtk");
        Debug.LogWarning(transform.name + ": LoadModelAtk", gameObject);
    }

    protected virtual void LoadModelDead()
    {
        if (this.modelAtk != null) return;
        this.modelAtk = transform.Find("ModelDead");
        Debug.LogWarning(transform.name + ": LoadModelDead", gameObject);
    }

    public virtual void Disable()
    {
        this.modelAtk.gameObject.SetActive(false);
        this.modelDead.gameObject.SetActive(false);
        this.modelIdlde.gameObject.SetActive(true);
    }

    public virtual void Enable()
    {
        this.modelAtk.gameObject.SetActive(true);
        this.modelIdlde.gameObject.SetActive(false);
    }

    public virtual void IsDead()
    {
        this.modelDead.gameObject.SetActive(true);
        this.modelAtk.gameObject.SetActive(false);
        this.modelIdlde.gameObject.SetActive(false);
    }
}
