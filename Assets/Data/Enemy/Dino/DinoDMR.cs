using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class DinoDMR : DamgeReceiver
{
    [SerializeField] protected PolygonCollider2D polygonCollider2;
    public PolygonCollider2D PolygonCollider2 { get => polygonCollider2; set => polygonCollider2 = value; }
    [SerializeField] protected Rigidbody2D rigidbody2;

    [SerializeField] protected DinoCtrl dinoCtrl;
    public DinoCtrl DinoCtrl => dinoCtrl;

    protected override void OnDisable()
    {
        base.OnDisable();
        isDead = false;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigid();
        this.LoadDinoCtrl();
    }

    protected virtual void LoadCollider(){
        if(this.PolygonCollider2 != null) return;
        this.PolygonCollider2 = transform.GetComponent<PolygonCollider2D>();
        this.PolygonCollider2.isTrigger = true;
        Debug.LogWarning(transform.name + "LoadCollider", gameObject);
    }

    protected virtual void LoadRigid(){
        if(this.rigidbody2 != null) return;
        this.rigidbody2 = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2.isKinematic = true;
        Debug.LogWarning(transform.name + "LoadRigid", gameObject);
    }

    protected virtual void LoadDinoCtrl()
    {
        if (this.dinoCtrl != null) return;
        this.dinoCtrl = transform.GetComponentInParent<DinoCtrl>();
        Debug.LogWarning(transform.name + "LoadDinoCtrl", gameObject);
    }

    protected override void OnDead()
    {
        dinoCtrl.DinoStateController.ChangeState(new DinoDeathState(dinoCtrl));
        AudioManager.Instance.PlayAudio("DinoDead");
        UIManager.Instance.SetPoint();
    }

    public void DeadEvent()
    {
        dinoCtrl.DinoDespawn.DespawnObject();
    }
}
