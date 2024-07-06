using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement :  TruongMonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed;
    [SerializeField] protected Transform gunPos;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGunPos();
    }

    void FixedUpdate() {
        //this.GetTargetPos();
        //this.LookAtTarget();   
        //this.LookDirection();
    }
    void Update() {
        this.LookAtTarget();
    }

    protected virtual void LoadGunPos(){
        if(this.gunPos != null) return;
        this.gunPos = transform.GetComponentInParent<GunCtrl>().Model;
        Debug.LogWarning(transform.name + ": LoadGunPos", gameObject);
    }

    protected virtual void LookAtTarget(){

        this.targetPos = InputManager.Instance.MouseWorldPos - gunPos.position;
        float angle = Mathf.Atan2(this.targetPos.y, this.targetPos.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        this.gunPos.rotation = Quaternion.Slerp(gunPos.rotation, rot, this.speed * Time.deltaTime);
    }

    /*protected virtual void LookDirection(){
        Vector3 direction = transform.parent.position - this.targetPos;
        transform.parent.position = direction;
    }*/
}
