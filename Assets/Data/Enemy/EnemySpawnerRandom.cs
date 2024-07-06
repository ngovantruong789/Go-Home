using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRandom : TruongMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    [SerializeField] protected List<Transform> listEnemyUp;
    [SerializeField] protected List<Transform> listEnemyDown;
    [SerializeField] protected int upDown;
    [SerializeField] protected float timerSpawn;
    [SerializeField] protected float timerMax = 3f;
    [SerializeField] protected float timerSpawnDelay = 0.5f;
    [SerializeField] protected bool isSpawn;
    [SerializeField] protected bool isStop;

    protected override void Start()
    {
        base.Start();
        ResetSpawn();
        timerSpawn = timerMax;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        LoadListSpawn();
        LoadPosSpawn();
    }

    protected virtual void FixedUpdate() {
        Spawning();
    }
    #region Load Data
    protected virtual void LoadEnemyCtrl(){
        if(this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + "LoadEnemyCtrl", gameObject);
    }

    protected void LoadListSpawn()
    {
        foreach(Transform transform in enemyCtrl.EnemySpawner.Prefab)
        {
            EnemyInfor enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(transform.name);
            if(enemyInfor == null) continue;
            if (enemyInfor.isSpecial) continue;
            if (enemyInfor.isBoss) continue;
            if(enemyInfor.isUp) listEnemyUp.Add(transform);
            else if(!enemyInfor.isUp) listEnemyDown.Add(transform);
        }
    }

    protected void LoadPosSpawn()
    {
        foreach (Transform transform in listEnemyUp)
        {
            EnemyInfor enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(transform.name);
            if (enemyInfor == null) continue;

            Vector3 pos = enemyCtrl.EnemySpawnPoints.GetPosByName(enemyInfor.spawnPointName);
            enemyInfor.SetSpawnPoint(pos);
        }

        foreach (Transform transform in listEnemyDown)
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
        if (isStop) return;
        if (isSpawn) return;
        timerSpawn -= Time.fixedDeltaTime;
        if (timerSpawn > 0) return;
        timerSpawn = timerMax;

        upDown = GetUpDown();

        if (upDown == 1) StartCoroutine(SpawnEnemyUp());
        else StartCoroutine(SpawnEnemyDown());
    }

    #region SpawnEnemyUp
    protected IEnumerator SpawnEnemyUp()
    {
        isSpawn = true;
        int rand = GetEnemyUp();
        int randNumber = GetNumberSpawnUp(rand);
        Vector3 pos = GetPosSpawn(rand);

        //Debug.Log("SpawnEnemyUp, GetEnemyUp: " + rand);
        //Debug.Log("SpawnEnemyUp, randNumber: " + randNumber);
        for (int i = 0; i < randNumber; i++)
        {
            Transform prefab = EnemySpawner.Instance.Spawn(listEnemyUp[rand].name, pos, Quaternion.identity);
            prefab.gameObject.SetActive(true);
            yield return new WaitForSeconds(timerSpawnDelay);
        }

        isSpawn = false;
    }

    protected int GetEnemyUp()
    {
        int rand = UnityEngine.Random.Range(0, listEnemyUp.Count);
        EnemyInfor enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(listEnemyUp[rand].name);

        while ((enemyInfor.isMax || enemyInfor.levelToSpawn > GetLevel()) && listEnemyUp.Count > 1)
        {
            rand = UnityEngine.Random.Range(0, listEnemyUp.Count);
            enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(listEnemyUp[rand].name);
        }

        //Debug.Log("GetEnemyDown: " +  rand);
        return rand;
    }

    protected int GetNumberSpawnUp(int index)
    {
        EnemyInfor enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(listEnemyUp[index].name);
        enemyInfor.AddSpawn();
        return UnityEngine.Random.Range(1, enemyInfor.maxSpawn + 1);
    }
    #endregion SpawnEnemyUp

    #region SpawnEnemyDown
    protected IEnumerator SpawnEnemyDown()
    {
        isSpawn = true;
        int rand = GetEnemyDown();
        int randNumber = GetNumberSpawnDown(rand);
        Vector3 pos = GetPosSpawn(rand);

        //Debug.Log("SpawnEnemyDown, GetEnemyUp: " + rand);
        //Debug.Log("SpawnEnemyDown, randNumber: " + randNumber);
        for (int i = 0; i < randNumber; i++)
        {
            Transform prefab = EnemySpawner.Instance.Spawn(listEnemyDown[rand].name, pos, Quaternion.identity);
            prefab.gameObject.SetActive(true);
            yield return new WaitForSeconds(timerSpawnDelay);
        }
        isSpawn = false;
    }

    protected int GetEnemyDown()
    {
        int rand = UnityEngine.Random.Range(0, listEnemyDown.Count);
        EnemyInfor enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(listEnemyDown[rand].name);

        while ((enemyInfor.isMax || enemyInfor.levelToSpawn > GetLevel()) && listEnemyDown.Count > 1)
        {
            rand = UnityEngine.Random.Range(0, listEnemyDown.Count);
            enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(listEnemyDown[rand].name);
        }

        //Debug.Log("GetEnemyDown: " +  rand);
        return rand;
    }

    protected int GetNumberSpawnDown(int index)
    {
        EnemyInfor enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(listEnemyDown[index].name);
        enemyInfor.AddSpawn();
        return UnityEngine.Random.Range(1, enemyInfor.maxSpawn + 1);
    }
    #endregion SpawnEnemyDown


    protected int GetUpDown()
    {
        int level = GameLevelManager.Instance.GetLevel();
        if (level <= 2) return 2;

        return UnityEngine.Random.Range(1, 3);
    }

    protected Vector3 GetPosSpawn(int index)
    {
        EnemyInfor enemyInfor = null;
        if(upDown == 1) enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(listEnemyUp[index].name);
        else enemyInfor = enemyCtrl.EnemySO.GetEnemyInfor(listEnemyDown[index].name);
        return enemyInfor.spawnPoint;
    }

    protected int GetLevel()
    {
        return GameLevelManager.Instance.GetLevel();
    }

    protected void ResetSpawn()
    {
        EnemySO enemySO = enemyCtrl.EnemySO;
        enemySO.ResetSpawn();
    }

    public bool CheckBossSpawn()
    {
        return enemyCtrl.BossSpawner.IsSpawn;
    }

    public void SetIsStop(bool isStop)
    {
        this.isStop = isStop;
    }
}
