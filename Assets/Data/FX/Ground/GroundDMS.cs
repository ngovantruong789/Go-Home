using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class GroundDMS : DamageSender
{
    [SerializeField] protected Rigidbody2D rigidbody2;
    [SerializeField] protected CircleCollider2D circleCollider2;
    [SerializeField] protected GroundCtrl groundCtrl;

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetValue();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigid();
        this.LoadCollider();
        this.LoadGroundCtrl();
    }

    protected virtual void LoadGroundCtrl()
    {
        if (this.groundCtrl != null) return;
        this.groundCtrl = transform.GetComponentInParent<GroundCtrl>();
        Debug.LogWarning(transform.name + ": LoadGroundCtrl", gameObject);
    }

    protected virtual void LoadRigid()
    {
        if (this.rigidbody2 != null) return;
        this.rigidbody2 = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2.gravityScale = 0.4f;
        Debug.LogWarning(transform.name + ": LoadRigid", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if(this.circleCollider2 != null) return;
        this.circleCollider2 = transform.GetComponent<CircleCollider2D>();
        this.circleCollider2.offset = new Vector2(-0.01497226f, -0.007485724f);
        this.circleCollider2.radius = 0.3306057f;
        this.circleCollider2.isTrigger= true;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        //this.dDCtrl.DungDropperDMS.Send(other.transform);
        this.Send(other.transform);

        ActionPhysics(false, false);
        this.groundCtrl.GroundAnimator.EnableAnimator();
        Invoke(nameof(this.DespawnObj), 0.35f);

        AudioManager.Instance.PlayAudio("Impact");
    }

    public void ActionPhysics(bool colliderActive, bool simulatedRigid)
    {
        circleCollider2.enabled = colliderActive;
        rigidbody2.simulated = simulatedRigid;
    }

    protected virtual void DespawnObj()
    {
        this.groundCtrl.GroundDespawn.DespawnObject();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(transform.localPosition.x, 0f);
    }
}
