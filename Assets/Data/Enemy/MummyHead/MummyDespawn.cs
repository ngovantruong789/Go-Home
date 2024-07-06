using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
