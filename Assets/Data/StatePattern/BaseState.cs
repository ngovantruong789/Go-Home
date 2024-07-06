using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : TruongMonoBehaviour
{
    [SerializeField] protected IState state;
    public virtual void ChangeState(IState state)
    {
        if (this.state != null && this.state.GetType() == state.GetType()) return;
        this.state = state;
        if(this.state == null)
        {
            this.state.Exit();
            return;
        }

        this.state.Enter();
    }
}
