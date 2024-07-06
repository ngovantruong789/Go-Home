using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance => instance;

    public static string FXOne = "Smoke_1";
    protected override void Awake()
    {
        base.Awake();
        if(FXSpawner.instance != null) Debug.LogError("Only 1 FXSpawner allow to exits");
        FXSpawner.instance = this;
    }
}
