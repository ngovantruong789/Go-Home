using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyCtrl : TruongMonoBehaviour
{
    [SerializeField] protected MummyDMS mummyDMS;
    public MummyDMS MummyDMS => mummyDMS;

    [SerializeField] protected MummyMove mummyMove;
    public MummyMove MummyMove => mummyMove;

    [SerializeField] protected MummyDespawn mummyDespawn;
    public MummyDespawn MummyDespawn => mummyDespawn;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadMummyDMS();
        this.LoadMummyMove();
        this.LoadMummyDespawn();
    }

    protected virtual void LoadMummyDMS(){
        if(this.mummyDMS != null) return;
        this.mummyDMS = transform.GetComponentInChildren<MummyDMS>();
         Debug.LogWarning(transform.name + "LoadMummyDMS", gameObject);
    }

    protected virtual void LoadMummyMove(){
        if(this.mummyMove != null) return;
        this.mummyMove = transform.GetComponentInChildren<MummyMove>();
         Debug.LogWarning(transform.name + "LoadMummyMove", gameObject);
    }

    protected virtual void LoadMummyDespawn()
    {
        if (this.mummyDespawn != null) return;
        this.mummyDespawn = transform.GetComponentInChildren<MummyDespawn>();
        Debug.LogWarning(transform.name + "LoadMummyDespawn", gameObject);
    }
}
