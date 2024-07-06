using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class RedFireDMS : DamageSender
{
    [SerializeField] protected Rigidbody2D rigidbody2;
    [SerializeField] protected BoxCollider2D boxCollider2D;

    protected override void OnEnable()
    {
        base.OnEnable();
        AudioManager.Instance.PlayAudio("Fire1");
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigid();
        this.LoadBoxCollider2D();
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
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        this.boxCollider2D.isTrigger = true;
        this.boxCollider2D.offset = new Vector2(0.1145498f, 0.0801847f);
        this.boxCollider2D.size = new Vector2(0.9541801f, 3.405546f);
        Debug.LogWarning(transform.name + "LoadBoxCollider2D", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        this.Send(other.transform);
    }
}
