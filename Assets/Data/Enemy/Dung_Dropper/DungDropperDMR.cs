using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DungDropperDMR : DamgeReceiver
{
    [SerializeField] protected Rigidbody2D rigidbody2;

    [SerializeField] protected DDCtrl dDCtrl;
    public DDCtrl DDCtrl => dDCtrl;
    [SerializeField] protected Transform dDModel;
    [SerializeField] protected bool checkDead = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigid();
        this.LoadDDCtrl();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.checkDead = false;
    }
    protected virtual void LoadRigid()
    {
        if (this.rigidbody2 != null) return;
        this.rigidbody2 = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadRigid", gameObject);
    }

    protected virtual void LoadDDCtrl()
    {
        if (this.dDCtrl != null) return;
        this.dDCtrl = transform.GetComponentInParent<DDCtrl>();
        Debug.Log(transform.name + ": LoadDDCtrl", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        this.dDCtrl.DungDropperDMS.Send(other.transform);
    }

    protected override void OnDead()
    {
        if(this.hp <= 0) UIManager.Instance.SetPoint();
        this.DespawnObj();
    }

    protected virtual void DespawnObj()
    {
        this.checkDead = true;
    }
}
