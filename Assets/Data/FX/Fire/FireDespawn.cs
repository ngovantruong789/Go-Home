using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EffectSpawner.Instance.Despawn(transform.parent);
    }
}
