using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornAbstract : TruongMonoBehaviour
{
    [SerializeField] protected ThornCtrl thornCtrl;
    public ThornCtrl ThornCtrl => thornCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadThornCrl();
    }

    protected virtual void LoadThornCrl(){
        if(this.thornCtrl != null) return;
        this.thornCtrl = transform.parent.GetComponent<ThornCtrl>();
        Debug.LogWarning(transform.name + ": LoadThornCrl" , gameObject);
    }
}
