using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDMS : DamageSender
{
    [SerializeField] protected FireCtrl fireCtrl;
    public FireCtrl FireCtrl => fireCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFireCtrl();
    }

    protected virtual void LoadFireCtrl(){
        if(this.fireCtrl != null) return;
        this.fireCtrl = transform.GetComponentInParent<FireCtrl>();
        Debug.Log(transform.name + ": LoadFireCtrl", gameObject);
    }

    public override void Send(DamgeReceiver damgeReceiver)
    {
        base.Send(damgeReceiver);
        this.DestroyFire();
    }
    protected virtual void DestroyFire(){
        this.fireCtrl.FireDespawn.DespawnObject();
    }
}
