using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpecialSpawner : TruongMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    [SerializeField] protected Transform enemySpecial;
    [SerializeField] protected float timerSpawn;
    [SerializeField] protected float timerMax = 3f;
    [SerializeField] protected bool isSpawn;

    protected override void Start()
    {
        base.Start();
        timerSpawn = timerMax;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        LoadEnemySpecial();
        LoadSpawnPoint();
    }

    protected virtual void FixedUpdate()
    {
        Spawning();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + "LoadEnemyCtrl", gameObject);
    }

    protected virtual void LoadSpawnPoint()
    {
        EnemyInfor enemyInfor = GetEnemyInfor();
        Vector3 spawnPoint = enemyCtrl.EnemySpawnPoints.GetPosByName(enemyInfor.spawnPointName);
        enemyInfor.SetSpawnPoint(spawnPoint);
    }

    protected virtual EnemyInfor GetEnemyInfor()
    {
        return enemyCtrl.EnemySO.GetEnemyInfor(enemySpecial.name);
    }

    protected int GetNumberSpawn()
    {
        return GetEnemyInfor().maxSpawn;
    }

    protected Vector3 GetPosSpawn()
    {
        return GetEnemyInfor().spawnPoint;
    }

    protected virtual void Spawning()
    {
        if (isSpawn) return;
        timerSpawn -= Time.fixedDeltaTime;
        if (timerSpawn > 0) return;
        timerSpawn = timerMax;

        StartCoroutine(SpawnEnemySpecial());
    }

    protected virtual int GetLevel()
    {
        return GameLevelManager.Instance.GetLevel();
    }

    protected abstract void LoadEnemySpecial();
    protected abstract IEnumerator SpawnEnemySpecial();
}
