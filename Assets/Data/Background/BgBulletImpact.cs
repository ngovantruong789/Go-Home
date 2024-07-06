using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgBulletImpact : TruongMonoBehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D rigidbody2;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigid();
    }
    protected virtual void LoadCollider(){
        if(this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        this.boxCollider2D.offset = new Vector2(-7.014951f, -5.03264f);
        this.boxCollider2D.size = new Vector2(5.870098f, 2.846518f);
        this.boxCollider2D.isTrigger = true;
        Debug.LogWarning(transform.parent.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigid(){
        if(this.rigidbody2 != null) return;
        this.rigidbody2 = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2.isKinematic = true;
        Debug.LogWarning(transform.parent.name + ": LoadRigid", gameObject);
    }
}
