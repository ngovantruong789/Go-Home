using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : TruongMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected List<Transform> listBoss;
    [SerializeField] protected float timerSpawn;
    [SerializeField] protected float timerSpawnMax;
    [SerializeField] protected bool isSpawn = false;
    public bool IsSpawn => isSpawn;

    protected override void Start()
    {
        base.Start();
        timerSpawn = timerSpawnMax;
    }

    private void FixedUpdate()
    {
        Spawning();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        LoadListSpawn();
        LoadPosSpawn();
    }

    #region Load Data
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + "LoadEnemyCtrl", gameObject);
    }

    protected void LoadListSpawn()
    {
        foreach (Transform transform in enemyCtrl.EnemySpawner.Prefab)
        {
            EnemyInfor enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(transform.name);
            if (enemyInfor == null) continue;
            if (enemyInfor.isSpecial) continue;
            if (enemyInfor.isBoss) listBoss.Add(transform);
        }
    }

    protected void LoadPosSpawn()
    {
        foreach (Transform transform in listBoss)
        {
            EnemyInfor enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(transform.name);
            if (enemyInfor == null) continue;

            Vector3 pos = enemyCtrl.EnemySpawnPoints.GetPosByName(enemyInfor.spawnPointName);
            enemyInfor.SetSpawnPoint(pos);
        }
    }
    #endregion Load Data

    protected void Spawning()
    {
        if (isSpawn) return;
        timerSpawn -= Time.fixedDeltaTime;
        if (timerSpawn >= 0) return;
        timerSpawn = timerSpawnMax;
        isSpawn = true;
        SpawnBoss();

        BgMovement bgMovement = FindObjectOfType<BgMovement>();
        bgMovement.SetIsStop(true);
    }

    protected void SpawnBoss()
    {
        int rand = RandomBoss();
        Vector3 pos = GetPosSpawn(rand);
        Transform prefab = EnemySpawner.Instance.Spawn(listBoss[rand].name, pos, Quaternion.identity);
        prefab.gameObject.SetActive(true);
    }

    protected int RandomBoss()
    {
        return Random.Range(0, listBoss.Count);
    }
    protected Vector3 GetPosSpawn(int index)
    {
        EnemyInfor enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(listBoss[index].name);
        return enemyInfor.spawnPoint;
    }

    public void SetIsSpawn(bool isSpawn)
    {
        this.isSpawn = isSpawn;
    }
}
