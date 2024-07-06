using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ThornImpact : ThornAbstract
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D rigid2D;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigid();
    }
    protected virtual void LoadCollider(){
        if(this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        this.boxCollider2D.offset = new Vector2(0, 0);
        this.boxCollider2D.size = new Vector2(1.27f, 1.34f);
        this.boxCollider2D.isTrigger = true;
        Debug.LogWarning(transform.parent.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigid(){
        if(this.rigid2D != null) return;
        this.rigid2D = transform.GetComponent<Rigidbody2D>();
        this.rigid2D.isKinematic = true;
        Debug.LogWarning(transform.parent.name + ": LoadRigid", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        CharacterImpact characterImpact = other.GetComponent<CharacterImpact>();

        if (characterImpact == null) return;
        this.thornCtrl.ThornDMS.Send(other.transform);
    }
}
