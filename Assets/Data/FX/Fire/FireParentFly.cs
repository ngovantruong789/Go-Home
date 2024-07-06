using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParentFly : TruongMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.left;

    protected virtual void Update() {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);    
    }
}
