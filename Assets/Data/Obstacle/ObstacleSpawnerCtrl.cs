using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerCtrl : TruongMonoBehaviour
{
    [SerializeField] protected EnemySpawnPoints enemySpawnPoints;
    public EnemySpawnPoints EnemySpawnPoints => enemySpawnPoints;

    [SerializeField] protected ObstacleSpawner obstacleSpawner;
    public ObstacleSpawner ObstacleSpawner => obstacleSpawner;

    [SerializeField] protected EnemySpawnerRandom enemySpawnerRandom;
    public EnemySpawnerRandom EnemySpawnerRandom => enemySpawnerRandom;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawnPoints();
        this.LoadObstacleSpawner();
        this.LoadEnemySpawnerRandom();
    }
    protected virtual void LoadEnemySpawnPoints(){
        if(this.enemySpawnPoints != null) return;
        this.enemySpawnPoints = Transform.FindObjectOfType<EnemySpawnPoints>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawnPoints", gameObject);
    }

    protected virtual void LoadObstacleSpawner(){
        if(this.obstacleSpawner != null) return;
        this.obstacleSpawner = transform.GetComponent<ObstacleSpawner>();
        Debug.LogWarning(transform.name + ": LoadObstacleSpawner", gameObject);
    }

    protected virtual void LoadEnemySpawnerRandom()
    {
        if (this.enemySpawnerRandom != null) return;
        this.enemySpawnerRandom = Transform.FindObjectOfType<EnemySpawnerRandom>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawnerRandom", gameObject);
    }
}
