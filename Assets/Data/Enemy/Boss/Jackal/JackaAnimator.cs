using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackaAnimator : BaseAnimator
{
    [SerializeField] protected JackaCtrl bossCtrl;
    [SerializeField] protected JackaHeadCtrl jackaHeadCtrl;
    public JackaHeadCtrl JackaHeadCtrl => jackaHeadCtrl;

    protected override void OnEnable()
    {
        base.OnEnable();
        SetActiveChildren(true);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBossCtrl();
        LoadJackaHeadCtrl();
    }
    protected virtual void LoadBossCtrl()
    {
        if (this.bossCtrl != null) return;
        this.bossCtrl = transform.GetComponentInParent<JackaCtrl>();
        Debug.LogWarning(transform.name + ": LoadBossCtrl", gameObject);
    }

    protected virtual void LoadJackaHeadCtrl()
    {
        if (this.jackaHeadCtrl != null) return;
        this.jackaHeadCtrl = transform.GetComponentInChildren<JackaHeadCtrl>();
        Debug.LogWarning(transform.name + ": LoadJackaHeadCtrl", gameObject);
    }

    public void SetActiveHead(bool active)
    {
        jackaHeadCtrl.gameObject.SetActive(active);
    }

    public void SetActiveChildren(bool active)
    {
        foreach(Transform transform in transform) 
            transform.gameObject.SetActive(active);
    }
}
