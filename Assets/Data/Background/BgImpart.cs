using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BgImpart : TruongMonoBehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D trigger2D;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadTrigger();
    }
    protected virtual void LoadCollider(){
        if(this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        this.boxCollider2D.offset = new Vector2(14.5f, -4.39f);
        this.boxCollider2D.size = new Vector2(67.8f, 0.67f);
        Debug.LogWarning(transform.name + "LoadCollider", gameObject);
    }

    protected virtual void LoadTrigger(){
        if(this.trigger2D != null) return;
        this.trigger2D = transform.GetComponent<Rigidbody2D>();
        this.trigger2D.isKinematic = true;
        Debug.LogWarning(transform.name + "LoadTrigger", gameObject);
    }
}
