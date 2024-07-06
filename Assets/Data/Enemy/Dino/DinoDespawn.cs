using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EnemyCtrl enemyCtrl = transform.GetComponentInParent<EnemyCtrl>();
        EnemyInfor enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(transform.parent.name);
        enemyInfor.DetuctCount();

        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
