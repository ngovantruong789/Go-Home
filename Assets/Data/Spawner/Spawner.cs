using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : TruongMonoBehaviour
{
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform holder;
    public Transform Holder => holder;

    [SerializeField] protected int countEnemyDown = 0;
    public int CountEnemyDown { get => countEnemyDown; set => countEnemyDown = value; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
        this.LoadPrefabs();
    }
    protected virtual void LoadHolder(){
        if(this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs(){
        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj){
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs(){
        foreach(Transform prefab in prefabs){
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation){
        Transform prefab = this.GetPrefabsByName(prefabName);
        if(prefab == null){
            Debug.LogWarning("Prefab not found");
            return null;
        }
        return this.Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation){
        Transform newPrefab = this.GetPrefabFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.parent = this.holder;
        return newPrefab;
    }

    public virtual void Despawn(Transform prefabName){
        this.poolObjs.Add(prefabName);
        prefabName.gameObject.SetActive(false);
    }

    protected virtual Transform GetPrefabsByName(string prefabName){
        foreach(Transform prefab in this.prefabs){
            if(prefab.name == prefabName)
                return prefab;
        }
        return null;
    }

    protected virtual Transform GetPrefabFromPool(Transform prefab){
        foreach(Transform poolObj in this.poolObjs){
            if(poolObj.name == prefab.name){
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
}
