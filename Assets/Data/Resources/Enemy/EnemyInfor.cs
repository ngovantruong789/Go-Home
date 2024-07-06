using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyInfor
{
    public string enemyName;
    public int levelToSpawn;
    public string spawnPointName;
    public Vector3 spawnPoint;
    public int countSpawn;
    public int limitSpawn;
    public int maxSpawn;
    public bool isSpecial;
    public bool isUp;
    public bool isMax;
    public bool isBoss;

    public void AddSpawn()
    {
        if (limitSpawn == 0) return;
        countSpawn++;
        if (countSpawn >= limitSpawn) SetIsMax(true);
    }

    public void DetuctCount()
    {
        if (limitSpawn == 0) return;
        countSpawn--;
        if(countSpawn < limitSpawn) SetIsMax(false);
    }

    public void SetIsMax(bool value)
    {
        isMax = value;
    }

    public void SetSpawnPoint(Vector3 spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }

    public void ResetValue()
    {
        countSpawn = 0;
        isMax = false;
    }
}
