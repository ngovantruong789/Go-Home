using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : TruongMonoBehaviour
{
    protected virtual void FixedUpdate() {
        this.CheckDespawn();
    }

    protected virtual void CheckDespawn(){
        if(!this.CanSpawn()) return;
        this.DespawnObject();
    }

    public virtual void DespawnObject(){
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanSpawn();
}
