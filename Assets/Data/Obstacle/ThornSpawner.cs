using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornSpawner : TruongMonoBehaviour
{
    [SerializeField] protected ObstacleSpawnerCtrl obstacleSpawnerCtrl;
    [SerializeField] protected float randomDelay = 3f;
    [SerializeField] protected float randomTimer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstacleCtrl();
    }

    protected virtual void FixedUpdate() {
        this.ObstacleSpawning();
    }
    protected virtual void LoadObstacleCtrl(){
        if(this.obstacleSpawnerCtrl != null) return;
        this.obstacleSpawnerCtrl = GetComponent<ObstacleSpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadObstacleCtrl", gameObject);
    }
    protected virtual void ObstacleSpawning(){
        this.randomTimer += Time.fixedDeltaTime;
        if(this.randomTimer < this.randomDelay) return;
        randomTimer = 0;

        Transform ranPoint = this.obstacleSpawnerCtrl.EnemySpawnPoints.SpawmPointsThree();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform obj = this.obstacleSpawnerCtrl.ObstacleSpawner.Spawn(ObstacleSpawner.obstacle, pos, rot);
        obj.gameObject.SetActive(true);
    }
}
