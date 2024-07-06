using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : TruongMonoBehaviour
{
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    [SerializeField] protected BulletDMS bulletDMS;
    public BulletDMS BulletDMS  => bulletDMS;

    [SerializeField] protected Transform characterPos;
    public Transform CharacterPos { get => characterPos; set => characterPos = value; }

    [SerializeField] protected CharacterImpact characterImpact;
    public CharacterImpact CharacterImpact => characterImpact;

    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDamageSender();
        this.LoadBulletDespawn();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadBulletDamageSender(){
        if(this.bulletDMS != null) return;
        this.bulletDMS = transform.GetComponentInChildren<BulletDMS>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadBulletDespawn(){
        if(this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = Transform.FindObjectOfType<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
}
