using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletImpact : BulletAbstract
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D isTrigger;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadisTrigger();
    }
    protected virtual void LoadCollider(){
        if(this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        this.boxCollider2D.isTrigger = true;
        this.boxCollider2D.offset = new Vector2(0.07f, 0);
        this.boxCollider2D.size = new Vector2(0.3f, 0.08f);
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadisTrigger(){
        if(this.isTrigger != null) return;
        this.isTrigger = transform.GetComponent<Rigidbody2D>();
        this.isTrigger.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadisTrigger", gameObject);
    }
    protected void OnTriggerEnter2D(Collider2D other) {
        CharacterImpact characterImpact = other.GetComponent<CharacterImpact>();
        BgBulletImpact bgBulletImpact = other.GetComponent<BgBulletImpact>();
        BgImpart bgImpart = other.GetComponent<BgImpart>();

        if(bgBulletImpact != null) this.CharacterFly();
        if (bgImpart != null) this.bulletCtrl.BulletDMS.DestroyBullet();

        if(characterImpact == null)
        {
            ThornImpact thornImpact = other.GetComponent<ThornImpact>();

            if (thornImpact != null) AudioManager.Instance.PlayAudio("BulletImpactMetal");
            else AudioManager.Instance.PlayAudio("BulletImpact");
        }

        if (characterImpact != null) return;
        this.bulletCtrl.BulletDMS.Send(other.transform);
    }

    protected virtual void CharacterFly(){
        this.bulletCtrl.CharacterImpact.FlyCharacter();
    }
}
