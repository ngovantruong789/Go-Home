using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAnimator : TruongMonoBehaviour
{
    [SerializeField] protected Animator animator;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.DisableAnimator();
    }
    public virtual void EnableAnimator()
    {
        this.animator.SetBool("GroundIlde", false);
    }

    public virtual void DisableAnimator()
    {
        this.animator.SetBool("GroundIlde", true);
    }
}
