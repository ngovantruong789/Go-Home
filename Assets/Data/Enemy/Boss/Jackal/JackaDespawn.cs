using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackaDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        BossSpawner bossSpawner = FindObjectOfType<BossSpawner>();
        bossSpawner.SetIsSpawn(false);
        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
