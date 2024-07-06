using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemySO : ScriptableObject
{
    public List<EnemyInfor> enemies;

    /*public void AddSpawn(string enemyName)
    {
        foreach(EnemyInfor enemyInfor in enemies)
        {
            if (enemyInfor.enemyName != enemyName) continue;
            if (enemyInfor.limitSpawn == 0) break;
            enemyInfor.AddSpawn();
            break;
        }
    }

    public void DetuctCount(string enemyName) {
        foreach (EnemyInfor enemyInfor in enemies)
        {
            if (enemyInfor.enemyName != enemyName) continue;
            if (enemyInfor.limitSpawn == 0) break;
            enemyInfor.DetuctCount();
            break;
        }
    }

    public void SetIsMax(string enemyName, bool value)
    {
        foreach (EnemyInfor enemyInfor in enemies)
        {
            if (enemyInfor.enemyName != enemyName) continue;

            enemyInfor.SetIsMax(value);
            break;
        }
    }

    public bool GetIsMax(string enemyName)
    {
        foreach (EnemyInfor enemyInfor in enemies)
        {
            if (enemyInfor.enemyName != enemyName) continue;

            return enemyInfor.GetIsMax();
        }

        return false;
    }

    public bool GetIsUp(string enemyName)
    {
        foreach (EnemyInfor enemyInfor in enemies)
        {
            if (enemyInfor.enemyName != enemyName) continue;

            return enemyInfor.isUp;
        }

        return false;
    }

    public bool GetSpecial(string enemyName)
    {
        foreach (EnemyInfor enemyInfor in enemies)
        {
            if (enemyInfor.enemyName != enemyName) continue;

            return enemyInfor.isSpecial;
        }

        return false;
    }*/

    public EnemyInfor GetEnemyInfor(string enemyName)
    {
        foreach (EnemyInfor enemyInfor in enemies)
        {
            if (enemyInfor.enemyName != enemyName) continue;

            return enemyInfor;
        }

        return null;
    }

    public void ResetSpawn()
    {
        foreach(EnemyInfor enemyInfor in enemies)
            enemyInfor.ResetValue();
    }
}
