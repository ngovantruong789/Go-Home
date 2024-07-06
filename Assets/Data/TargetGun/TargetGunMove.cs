using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGunMove : TruongMonoBehaviour
{
    [SerializeField] protected Vector3 target;
    [SerializeField] protected float speed;
    protected void Update() {
        this.TargetMove();
    }

    protected virtual void TargetMove(){
        this.target = InputManager.Instance.MouseWorldPos;
        this.target.z = 0;
        transform.parent.position = this.target;
    }
}
