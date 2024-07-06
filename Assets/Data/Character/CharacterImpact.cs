using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterImpact : TruongMonoBehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D rigid2D;
    [SerializeField] protected CharacterCtrl characterCtrl;
    [SerializeField] protected float flyingForce;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigid();
    }

    protected void Update() {
        this.ResetPos();
        //this.CharacterFly();
    }

    protected virtual void ResetPos(){
        /*Quaternion objRot = transform.rotation;
        objRot.z = 0;
        transform.rotation = objRot;
        transform.position = new Vector3(-6.94f, transform.position.y, 0);

        float x = 0;
        if(transform.position.y >= x){
            this.speedFly = 0.5f;
            this.rigid2D.gravityScale = 1.5f;
            if(transform.position.y < 1) return;
            for(int i = 0; i < (int)transform.position.y - x; i++){
                this.rigid2D.gravityScale += 0.2f;
                if(this.rigid2D.gravityScale >= 2.5f) break;
            }
        }
        else{
            this.rigid2D.gravityScale = 1f;
            this.speedFly = 0.8f;
        }*/
    }
    protected virtual void LoadCollider(){
        if(this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        this.boxCollider2D.offset = new Vector2(-7.9f, -3.35f);
        this.boxCollider2D.size = new Vector2(1.29f, 1.29f);
        Debug.LogWarning(transform.parent.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigid(){
        if(this.rigid2D != null) return;
        this.rigid2D = transform.GetComponent<Rigidbody2D>();
        this.rigid2D.gravityScale = 2;
        Debug.LogWarning(transform.parent.name + ": LoadRigid", gameObject);
    }

    public virtual void FlyCharacter(){
        this.rigid2D.AddForce(Vector2.up * Time.fixedDeltaTime * this.flyingForce);
        //rigid2D.velocity = new Vector2(rigid2D.velocity.x, rigid2D.velocity.y + speedFly);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.layer != LayerMask.NameToLayer("Enemy")) return;

        
    }
}
