using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFireDespawn : DespawnByTime
{
    protected override void OnDisable()
    {
        base.OnDisable();
        ResetValue();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    public override void DespawnObject()
    {
        AttackSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        //JackaCtrl jackaCtrl = FindObjectOfType<JackaCtrl>();
        //jackaCtrl.JackaAttack.SetAttack(false);
    }
}
