using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureDMS : DamageSender
{
    protected override void OnDisable()
    {
        base.OnDisable();
        ResetValue();
    }

    public override void Send(DamgeReceiver damgeReceiver)
    {
        base.Send(damgeReceiver);
    }

    public void SetDamageAttack()
    {
        damage *= 2;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        damage = damageMax;
    }
}
