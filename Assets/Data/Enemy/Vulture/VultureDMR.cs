using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VultureDMR : DamgeReceiver
{
    [SerializeField] protected Rigidbody2D rigidbody2;
    [SerializeField] protected VultureCtrl vultureCtrl;
    [SerializeField] protected PolygonCollider2D polygonCollider2;

    public VultureCtrl VultureCtrl => vultureCtrl;
    public float HpMax { get => hpMax; set => hpMax = value; }
    public float Hp { get => hp; set => hp = value; }
    
    protected bool check = false;
    public bool Check { get => check; set => check = value; }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigid();
        this.LoadVultureCtrl();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetValue();
    }

    protected virtual void LoadRigid()
    {
        if (this.rigidbody2 != null) return;
        this.rigidbody2 = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadRigid", gameObject);
    }


    protected virtual void LoadVultureCtrl()
    {
        if (this.vultureCtrl != null) return;
        this.vultureCtrl = transform.GetComponentInParent<VultureCtrl>();
        Debug.LogWarning(transform.name + ": LoadVultureCtrl", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        this.vultureCtrl.VultureDMS.Send(other.transform);

        if(this.vultureCtrl.VultureMove.CheckMove) this.OnDead();
    }

    protected override void OnDead()
    {
        AudioManager.Instance.PlayAudio("VultureDeath");
        if(this.hp <= 0) UIManager.Instance.SetPoint();

        this.vultureCtrl.VultureAnimator.IsDead();
        this.polygonCollider2.enabled = false;
        if (this.vultureCtrl.VultureMove.CheckMove)
        {
            Invoke(nameof(this.DespawnObj), 0.3f);
            return;
        }
        this.check = true;
        Invoke(nameof(this.DespawnObj), 0.6f);
    }

    protected virtual void DespawnObj()
    {
        this.vultureCtrl.VultureDespawn.DespawnObject();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.polygonCollider2.enabled = true;
    }
}
