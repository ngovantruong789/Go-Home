using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : Spawner
{
    private static ObstacleSpawner instance;
    public static ObstacleSpawner Instance => instance;
    public static string obstacle = "Thorn";

    protected override void Awake() {
        base.Awake();
        if(ObstacleSpawner.instance != null) Debug.LogError("Only 1 ObstacleSpawner allow to exist");
        ObstacleSpawner.instance = this;
    }
}
