using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDMS : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;

    [SerializeField] protected int oldDamge;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetValue();
        DamageUp();
    }

    protected virtual void LoadBulletCtrl(){
        if(this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletCtrl", gameObject);
    }

    public override void Send(DamgeReceiver damgeReceiver)
    {
        base.Send(damgeReceiver);
        this.DestroyBullet();
    }

    public virtual void DestroyBullet(){
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }

    protected virtual void DamageUp()
    {
        JackaCtrl jackaCtrl = FindObjectOfType<JackaCtrl>();
        if (jackaCtrl == null) return;
        if (!jackaCtrl.gameObject.activeSelf) return;
        if (!jackaCtrl.JackaDMR.IsLowHP) return;
        if (damage >= damageMax) return;
        damage += 1;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.damage = oldDamge;
        //if (!TimePlayManager.Instance.Dead) this.damage = oldDamge;
    }
}
