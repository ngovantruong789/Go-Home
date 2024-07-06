using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningCtrl : TruongMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;

    [SerializeField] protected WarningActive warningActive;
    public WarningActive WarningActive => warningActive;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadWarningActive();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = Transform.FindObjectOfType<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void LoadWarningActive()
    {
        if (this.warningActive != null) return;
        this.warningActive = transform.GetComponentInChildren<WarningActive>();
        Debug.LogWarning(transform.name + ": LoadWarningActive", gameObject);
    }
}
