using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoints : SpawnPoints
{
    private static EnemySpawnPoints instance;
    public static EnemySpawnPoints Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public Vector3 GetPosByName(string name)
    {
        foreach(Transform transform in points)
            if (transform.name == name) return transform.position;

        return Vector3.zero;
    }
}
