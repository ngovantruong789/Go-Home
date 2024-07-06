using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl : TruongMonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;

    [SerializeField] protected EnemySpawnPoints enemySpawnPoints;
    public EnemySpawnPoints EnemySpawnPoints => enemySpawnPoints;

    [SerializeField] protected EnemySpawnerRandom enemySpawnerRandom;
    public EnemySpawnerRandom EnemySpawnerRandom => enemySpawnerRandom;

    [SerializeField] protected WarningCtrl warningCtrl;
    public WarningCtrl WarningCtrl => warningCtrl;

    [SerializeField] protected BossSpawner bossSpawner;
    public BossSpawner BossSpawner => bossSpawner;

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO => enemySO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
        this.LoadEnemySpawnPoints();
        this.LoadEnemySpawnerRandom();
        LoadBossSpawner();
        this.LoadWarningCtrl();
        LoadEnemySO();
    }
    protected virtual void LoadEnemySpawnPoints(){
        if(this.enemySpawnPoints != null) return;
        this.enemySpawnPoints = Transform.FindObjectOfType<EnemySpawnPoints>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawnPoints", gameObject);
    }

    protected virtual void LoadEnemySpawner(){
        if(this.enemySpawner != null) return;
        this.enemySpawner = transform.GetComponent<EnemySpawner>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawner", gameObject);
    }

    protected virtual void LoadEnemySpawnerRandom(){
        if(this.enemySpawnerRandom != null) return;
        this.enemySpawnerRandom = transform.GetComponent<EnemySpawnerRandom>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawnerRandom", gameObject);
    }

    protected virtual void LoadBossSpawner()
    {
        if (this.bossSpawner != null) return;
        this.bossSpawner = transform.GetComponent<BossSpawner>();
        Debug.LogWarning(transform.name + ": LoadBossSpawner", gameObject);
    }

    protected virtual void LoadWarningCtrl()
    {
        if (this.warningCtrl != null) return;
        this.warningCtrl = Transform.FindObjectOfType<WarningCtrl>();
        Debug.LogWarning(transform.name + ": LoadWarningCtrl", gameObject);
    }


    protected virtual void LoadEnemySO()
    {
        if (this.enemySO != null) return;
        string resPath = "Enemy/Enemy";
        enemySO = Resources.Load<EnemySO>(resPath);
    }
}
