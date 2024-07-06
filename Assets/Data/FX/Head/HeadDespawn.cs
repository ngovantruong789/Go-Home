using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EffectSpawner.Instance.Despawn(transform.parent);
    }
}
