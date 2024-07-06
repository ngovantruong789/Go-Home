using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackaHeadCtrl : TruongMonoBehaviour
{
    [SerializeField] protected JackaHeadStateController jackaHeadState;
    public JackaHeadStateController JackaHeadState => jackaHeadState;

    [SerializeField] protected JackaHeadAnimator headAnimator;
    public JackaHeadAnimator HeadAnimator => headAnimator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLink();
    }
    
    protected void LoadLink()
    {
        jackaHeadState = GetComponent<JackaHeadStateController>();
        headAnimator = GetComponent<JackaHeadAnimator>();
    }
}
