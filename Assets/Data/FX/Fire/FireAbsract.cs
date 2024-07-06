using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbsract : TruongMonoBehaviour
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
}
