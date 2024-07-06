using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{

    protected override void OnEnable()
    {
        base.OnEnable();
        LoadCamera();
    }

    public override void DespawnObject()
    {
        AttackSpawner.Instance.Despawn(transform.parent);
        this.CreateFX();
    }

    protected virtual void CreateFX(){
        string fxName = this.GetImpactFX();
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform impact = FXSpawner.Instance.Spawn(fxName, pos, rot);
        impact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX(){
        return FXSpawner.FXOne;
    }
}
