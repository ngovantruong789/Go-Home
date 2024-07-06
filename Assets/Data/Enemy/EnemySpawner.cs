using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;
    public List<Transform> Prefab => prefabs;

    public static string enemyOne = "EnemyOne";
    public static string enemyTwo = "MummyHead";

    protected override void Awake() {
        base.Awake();
        if(EnemySpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        EnemySpawner.instance = this;
    }
}
