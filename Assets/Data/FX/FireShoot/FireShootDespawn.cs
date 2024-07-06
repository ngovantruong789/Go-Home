using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShootDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        EffectSpawner.Instance.Despawn(transform.parent);
    }
}
