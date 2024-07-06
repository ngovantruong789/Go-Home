using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : Spawner
{
    private static EffectSpawner instance;
    public static EffectSpawner Instance => instance;
    public static string fireOne = "Fire_1";
    public static string ground = "Ground_1";
    public static string head = "Head_1";
    public static string redFire = "RedFire_1";
    public static string fireShoot = "FireShoot_1";
    

    protected override void Awake() {
        base.Awake();
        if(EffectSpawner.instance != null) Debug.LogError("Only 1 EffectSpawner allow to exist");
        EffectSpawner.instance = this;
    }
}
