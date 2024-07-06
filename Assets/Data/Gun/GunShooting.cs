using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GunShooting : TruongMonoBehaviour
{
    [SerializeField] protected bool isShootting = false;
    [SerializeField] protected Transform gunPos;
    [SerializeField] protected float timeLimit;
    [SerializeField] protected float timer;
    [SerializeField] protected float offsetX;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGunPos();
    }
    private void Update() {
        this.CheckIsShooting();
    }
    private void FixedUpdate() {
        this.Shooting();
    }

    protected virtual void LoadGunPos(){
        if(this.gunPos != null) return;
        this.gunPos = transform.GetComponentInParent<GunCtrl>().Model;
    }

    protected virtual void Shooting(){
        if(!isShootting) return;

        this.timer += Time.fixedDeltaTime;
        if(this.timer < this.timeLimit) return;
        this.timer = 0;

        Vector3 pos = gunPos.position;
        Quaternion rot = this.gunPos.rotation;

        this.FireShoot(pos, rot);
        Transform newBullet = AttackSpawner.Instance.Spawn(AttackSpawner.bulletOne, pos, rot);

        if(newBullet == null) return;
        newBullet.gameObject.SetActive(true);

        AudioManager.Instance.PlayAudio("AudioGun");
    }

    protected virtual bool CheckIsShooting(){
        this.isShootting = InputManager.Instance.OnFiring == 1;
        return this.isShootting;
    }

    protected virtual void FireShoot(Vector3 pos, quaternion rot)
    {
        Transform newFire = EffectSpawner.Instance.Spawn(EffectSpawner.fireShoot, pos, rot);
        newFire.gameObject.SetActive(true);
    }
}
