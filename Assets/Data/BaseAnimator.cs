using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimator : TruongMonoBehaviour
{
    [SerializeField] protected Animator animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
    }

    protected void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
    }

    public virtual void SetBoolParameterWithName(string name)
    {
        foreach(AnimatorControllerParameter parameter in animator.parameters)
        {
            if(parameter.type != AnimatorControllerParameterType.Bool) continue;
            if(parameter.name != name)
            {
                animator.SetBool(name, false);
                continue;
            }
            animator.SetBool(name, true);
        }
    }

    public virtual void SetTriggerParameter(string name)
    {
        animator.SetTrigger(name);
    }
}
