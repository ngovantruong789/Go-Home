using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDStateController : BaseState
{
    protected override void OnDisable()
    {
        base.OnDisable();
        ResetValue();
    }

    private void FixedUpdate()
    {
        if (state == null) return;
        state.Execute();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        state = null;
    }
}
