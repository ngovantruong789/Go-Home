using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : Spawner
{
    private static AttackSpawner instance;
    public static AttackSpawner Instance => instance;
    public static string bulletOne = "Bullet_1";

    protected override void Awake() {
        base.Awake();
        if(AttackSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        AttackSpawner.instance = this;
    }
}
