using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : TruongMonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected Vector3 bulletFly = Vector3.right;

    void FixedUpdate() {
        this.BulletSpeed();
    }

    protected virtual void BulletSpeed(){
        transform.parent.Translate(this.bulletFly * this.speed * Time.fixedDeltaTime);   
    }
}
