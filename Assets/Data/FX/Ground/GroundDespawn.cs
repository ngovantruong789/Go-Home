using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDespawn : DespawnByDistance
{
    protected override void OnDisable()
    {
        base.OnDisable();
        //DespawnObject();
    }

    public override void DespawnObject()
    {
        AttackSpawner.Instance.Despawn(transform.parent);
        transform.parent.SetParent(AttackSpawner.Instance.Holder);
    }
}
