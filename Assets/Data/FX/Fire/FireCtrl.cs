using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : TruongMonoBehaviour
{
   [SerializeField] protected FireDespawn fireDespawn;
    public FireDespawn FireDespawn => fireDespawn;
    [SerializeField] protected FireDMS fireDMS;
    public FireDMS FireDMS => fireDMS;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFireDamageSender();
        this.LoadFireDespawn();
    }

    protected virtual void LoadFireDamageSender(){
        if(this.fireDMS != null) return;
        this.fireDMS = transform.GetComponentInChildren<FireDMS>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadFireDespawn(){
        if(this.fireDespawn != null) return;
        this.fireDespawn = transform.GetComponentInChildren<FireDespawn>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }
}
