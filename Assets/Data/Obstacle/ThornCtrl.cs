using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornCtrl : TruongMonoBehaviour
{
    [SerializeField] protected ThornDMS thornDMS;
    public ThornDMS ThornDMS => thornDMS;

    [SerializeField] protected EnemySpawnerRandom enemySpawnerRandom;
    public EnemySpawnerRandom EnemySpawnerRandom => enemySpawnerRandom;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDMS();
        this.LoadEnemySpawnerRandom();
    }

    protected virtual void LoadDMS(){
        if(this.thornDMS != null) return;
        this.thornDMS = transform.GetComponentInChildren<ThornDMS>();
        Debug.LogWarning(transform.name + ": LoadDMS" , gameObject);
    }

    protected virtual void LoadEnemySpawnerRandom()
    {
        if (this.enemySpawnerRandom != null) return;
        this.enemySpawnerRandom = Transform.FindObjectOfType<EnemySpawnerRandom>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawnerRandom", gameObject);
    }
}
