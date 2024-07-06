using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class FireImpact : FireAbsract
{
    [SerializeField] protected Rigidbody2D rigidbody2;
    [SerializeField] protected CircleCollider2D circleCollider2;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody2();
    }
    protected virtual void LoadRigidbody2(){
        if(this.rigidbody2 != null) return;
        this.rigidbody2 = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadRigidbody2", gameObject);
    }

    protected virtual void LoadCollider(){
        if(this.circleCollider2 != null) return;
        this.circleCollider2 = transform.GetComponent<CircleCollider2D>();
        this.circleCollider2.isTrigger = true;
        this.circleCollider2.radius = 0.26f;
        this.circleCollider2.offset = new Vector2(-0.19f, 0.007f);
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }
    
    protected void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        this.fireCtrl.FireDMS.Send(other.transform);
    }
}
