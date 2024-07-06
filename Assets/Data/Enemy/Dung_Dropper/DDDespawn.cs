using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        DungDropperSpawner spawner = GetComponentInParent<DungDropperSpawner>();
        spawner.ResetSpawn();
        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
