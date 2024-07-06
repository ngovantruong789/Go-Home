using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungDropperSpawner : EnemySpecialSpawner
{
    protected override void LoadEnemySpecial()
    {
        if (enemySpecial != null) return;
        foreach(Transform transform in enemyCtrl.EnemySpawner.Prefab)
            if(transform.name == "DungDropper")
                enemySpecial = transform;
    }

    protected override void Spawning()
    {
        if (GetLevel() < 2) return;
        if (GetEnemyInfor().isMax) return;
        base.Spawning();
    }

    protected override IEnumerator SpawnEnemySpecial()
    {
        isSpawn = true;
        WarningCtrl warningCtrl = FindObjectOfType<WarningCtrl>();
        warningCtrl.WarningActive.EnableModelWarning();
        yield return new WaitForSeconds(1.5f);
        warningCtrl.WarningActive.DisableModelWarning();
        
        Vector3 pos = GetPosSpawn();
        Transform prefab = enemyCtrl.EnemySpawner.Spawn(enemySpecial.name, pos, Quaternion.identity);
        prefab.gameObject.SetActive(true);
        GetEnemyInfor().AddSpawn();
        yield break;
    }

    public void ResetSpawn()
    {
        this.isSpawn = false;
        GetEnemyInfor().DetuctCount();
    }

    public bool CheckBossSpawn()
    {
        return enemyCtrl.BossSpawner.IsSpawn;
    }
}
