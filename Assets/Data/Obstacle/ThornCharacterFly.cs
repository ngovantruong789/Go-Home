using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornCharacterFly : BgBulletImpact
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.DisableCollider();
    }

    protected virtual void DisableCollider(){
        this.boxCollider2D.enabled = false;
        this.Invoke(nameof(this.EnableCollider), 4);
    }

    protected virtual void EnableCollider(){
        this.boxCollider2D.enabled = true;
    }
}
