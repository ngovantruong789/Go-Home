using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyCharacterFly : TruongMonoBehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D rigidbody2;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider2D();
        this.LoadRigid();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.DisableCollider();
        this.Invoke(nameof(this.EnableCollider), 6.5f);
    }

    protected virtual void LoadBoxCollider2D(){
        if(this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        this.boxCollider2D.offset = new Vector2(0.1574887f, 0.5977412f);
        this.boxCollider2D.size = new Vector2(0.5132167f, 0.3772037f);
        this.boxCollider2D.isTrigger = true;
        Debug.LogWarning(transform.parent.name + ": LoadCircleCollider2D", gameObject);
    }

    protected virtual void LoadRigid(){
        if(this.rigidbody2 != null) return;
        this.rigidbody2 = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2.isKinematic = true;
        Debug.LogWarning(transform.parent.name + ": LoadRigid", gameObject);
    }

    protected virtual void DisableCollider(){
        this.boxCollider2D.enabled = false;
    }

    protected virtual void EnableCollider(){
        this.boxCollider2D.enabled = true;
    }
}
