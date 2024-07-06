using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class HeadDMS : DamageSender
{
    [SerializeField] protected HeadCtrl headCtrl;
    [SerializeField] protected Rigidbody2D rigidbody2;
    [SerializeField] protected BoxCollider2D boxCollider2;

    protected void FixedUpdate()
    {
        CheckJackaDead();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHeadCtrl();
        this.LoadRigid();
        this.LoadBoxCollider2D();
    }

    protected virtual void LoadHeadCtrl()
    {
        if (this.headCtrl != null) return;
        this.headCtrl = transform.GetComponentInParent<HeadCtrl>();
        Debug.LogWarning(transform.name + "LoadHeadCtrl", gameObject);
    }

    protected virtual void LoadRigid()
    {
        if (this.rigidbody2 != null) return;
        this.rigidbody2 = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2.isKinematic = true;
        Debug.LogWarning(transform.name + "LoadRigid", gameObject);
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (this.boxCollider2 != null) return;
        this.boxCollider2 = transform.GetComponent<BoxCollider2D>();
        this.boxCollider2.isTrigger = true;
        Debug.LogWarning(transform.name + "LoadBoxCollider2D", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //despawn cais đầu khi bắn, tạo âm thanh phóng
        if (headCtrl.HeadAttack.IsBack && other.gameObject.name == "JackaDMR")
        {
            ResetValue();
            return;
        }
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        this.Send(other.transform);

        AudioManager.Instance.PlayAudio("Bite");
    }

    protected void CheckJackaDead()
    {
        JackaCtrl jackaCtrl = FindObjectOfType<JackaCtrl>();
        if (jackaCtrl == null) return;
        if (jackaCtrl.JackaDMR.IsDead) headCtrl.HeadDespawn.DespawnObject();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        JackaCtrl jackaCtrl = FindObjectOfType<JackaCtrl>();
        jackaCtrl.JackaAttack.SetAttack(false);
        jackaCtrl.JackaAnimator.SetActiveHead(true);
        headCtrl.HeadDespawn.DespawnObject();
    }

}
