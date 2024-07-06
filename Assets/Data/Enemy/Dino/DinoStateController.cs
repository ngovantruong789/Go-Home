using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoStateController : BaseState
{
    private void FixedUpdate()
    {
        if (state == null) return;
        state.Execute();
    }
}
