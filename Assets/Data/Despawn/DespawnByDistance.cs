using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float desLimit = 40f;
    [SerializeField] protected float desDistance = 0f;
    [SerializeField] protected Transform mainCam;

    protected override void Start()
    {
        base.Start();
        LoadCamera();
    }
    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadCamera();
    }
    protected virtual void LoadCamera(){
        if(this.mainCam != null) return;
        this.mainCam = UnityEngine.Camera.main.transform;
        //Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }

    protected override bool CanSpawn()
    {
        this.desDistance = Vector3.Distance(transform.position, this.mainCam.position);
        if(this.desDistance >= this.desLimit) return true;
        return false;
    }
}
