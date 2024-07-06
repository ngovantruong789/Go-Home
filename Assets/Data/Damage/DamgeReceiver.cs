using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamgeReceiver : TruongMonoBehaviour
{
    [SerializeField] protected float hp = 1;
    [SerializeField] protected float hpMax = 2;
    [SerializeField] protected bool isDead;
    public bool IsDead => isDead;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected virtual void Reborn(){
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public virtual void Add(int add){
        if(isDead) return;

        this.hp += add;
        if(this.hp > hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int deduct){
        if(isDead) return;

        this.hp -= deduct;
        if(this.hp <= 0) this.hp = 0;
        this.CheckIsDead();
    }

    protected virtual bool CheckDead(){
        return this.hp <= 0;
    }
    protected virtual void CheckIsDead(){
        if(!this.CheckDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}
