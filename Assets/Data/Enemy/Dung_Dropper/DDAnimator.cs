using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDAnimator : BaseAnimator
{
    [SerializeField] protected DDCtrl dDCtrl;
    public DDCtrl DDCtrl => dDCtrl;
    [SerializeField] protected Transform leftHand;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDDCtrl();
        LoadLeftHand();
    }

    protected virtual void LoadDDCtrl()
    {
        if (this.dDCtrl != null) return;
        this.dDCtrl = transform.GetComponentInParent<DDCtrl>();
        Debug.Log(transform.name + ": LoadDDCtrl", gameObject);
    }

    protected virtual void LoadLeftHand()
    {
        if (this.leftHand != null) return;
        this.leftHand = transform.Find("LeftHand");
        Debug.Log(transform.name + ": LoadLeftHand", gameObject);
    }

    public void SetTriggerParemeter(string name)
    {
        animator.SetTrigger(name);
    }

    public void SetTriggerLeftHand()
    {
        LeftHandAnimator animator = leftHand.GetComponent<LeftHandAnimator>();
        animator.SetTriggerParameter("Tr_Attack");
    }
}
