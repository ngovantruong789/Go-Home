using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAnimator : BaseAnimator
{
    [SerializeField] protected DinoCtrl dinoCtrl;
    [SerializeField] protected Transform eyes;
    [SerializeField] protected bool isCheckDead;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDinoCtrl();
        LoadEyes();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetValue();
    }
   
    protected virtual void LoadDinoCtrl(){
        if(this.dinoCtrl != null) return;
        this.dinoCtrl = transform.GetComponentInParent<DinoCtrl>();
        Debug.LogWarning(transform.name + "LoadDinoCtr", gameObject);
    }
    
    protected void LoadEyes()
    {
        if (this.eyes != null) return;
        eyes = transform.Find("Eyes");
    }

    public void AttackEvent()
    {
        StartCoroutine(dinoCtrl.DinoShooting.Shooting());
    }

    public void SetActiveEyes(bool active)
    {
        eyes.gameObject.SetActive(active);
    }

    public void DeadEvent()
    {
        dinoCtrl.DinoDMR.DeadEvent();
    }
}
