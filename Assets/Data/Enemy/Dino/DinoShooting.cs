using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoShooting : TruongMonoBehaviour
{
    [SerializeField] protected DinoCtrl dinoCtrl;
    [SerializeField] protected Transform dinoPos;
    [SerializeField] protected float timer;
    public float Timer => timer;
    [SerializeField] protected float timeLimit;
    [SerializeField] protected float timerShooting;
    [SerializeField] protected bool isShoot;
    public bool IsShoot => isShoot;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDinoPos();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.timer = 8f;
    }
    protected virtual void LoadDinoPos(){
        if(this.dinoPos != null) return;
        this.dinoPos = transform.GetComponentInParent<DinoCtrl>().transform;
        Debug.LogWarning(transform.name + "LoadDinoPos", gameObject);
    }

    protected virtual void LoadDinoCtrl(){
        if(this.dinoCtrl != null) return;
        this.dinoCtrl = transform.GetComponentInParent<DinoCtrl>();
    }
    public virtual IEnumerator Shooting(){
        Vector3 pos = this.dinoPos.position;
        Quaternion rot = this.dinoPos.rotation;
        Transform newFire = AttackSpawner.Instance.Spawn("Fire_1", pos, rot);

        if (newFire == null) yield break;
        newFire.gameObject.SetActive(true);

        AudioManager.Instance.PlayAudio("DinoShoot");
        yield return new WaitForSeconds(timerShooting);
        isShoot = false;
    }

    public virtual void CheckIsShooting(){
        bool isMove = dinoCtrl.DinoMove.IsMove;
        if (isMove) return;
        this.timer += Time.fixedDeltaTime;
        if(this.timer >= this.timeLimit){
            this.timer = 0;
            isShoot = true;
        }
    }
}
