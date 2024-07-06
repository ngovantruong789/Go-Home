using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float delay;
    [SerializeField] protected float timer;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTime();
    }

    protected virtual void ResetTime(){
        timer = 0;
    }

    protected override bool CanSpawn()
    {
        this.timer += Time.fixedDeltaTime;
        return this.timer >= this.delay;
    }
}
