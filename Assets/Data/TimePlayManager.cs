using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlayManager : TruongMonoBehaviour
{
    private static TimePlayManager instance;
    public static TimePlayManager Instance => instance;

    [SerializeField] protected EnemyCtrl enemyCtrl;

    [SerializeField] protected bool checkStopSpawn = false;
    public bool CheckStopSpawn { get => checkStopSpawn; set => checkStopSpawn = value; }

    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeLimit = 0f;
    [SerializeField] protected int countTime = 0;
    public int CountTime { get => countTime; set => countTime = value; }

    [SerializeField] protected bool dead = false;
    public bool Dead { get => dead; set => dead = value; }



    protected override void Awake()
    {
        base.Awake();
        if (TimePlayManager.instance != null) Debug.LogError("Only 1 TimePlayManager allow to exits");
        TimePlayManager.instance = this;
    }

    private void FixedUpdate()
    {
        this.Timing();
    }

    protected virtual void Timing()
    {
        
    }
}
