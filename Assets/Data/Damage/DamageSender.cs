using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : TruongMonoBehaviour
{
    [SerializeField] protected int damage = 2;
    [SerializeField] protected int damageMax = 2;
    public virtual void Send(Transform obj){
        DamgeReceiver damgeReceiver = obj.GetComponent<DamgeReceiver>();
        if(damgeReceiver == null) return;
        this.Send(damgeReceiver);
    }

    public virtual void Send(DamgeReceiver damgeReceiver){
        damgeReceiver.Deduct(this.damage);
    }
}
