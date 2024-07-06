using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackaLinked : TruongMonoBehaviour
{
    [SerializeField] protected JackaAnimator jackaAnimator;
    public JackaAnimator JackaAnimator => jackaAnimator;

    [SerializeField] protected JackaDMR jackaDMR;
    public JackaDMR JackaDMR => jackaDMR;

    [SerializeField] protected JackaDespawn jackaDespawn;
    public JackaDespawn JackaDespawn => jackaDespawn;

    [SerializeField] protected JackaAttack jackaAttack;
    public JackaAttack JackaAttack => jackaAttack;

    [SerializeField] protected JackaMove jackaMove;
    public JackaMove JackaMove => jackaMove;

    [SerializeField] protected JackaStateController jackaState;
    public JackaStateController JackaStateController => jackaState;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJackaStateController();
        this.LoadBossAnimator();
        this.LoadBossDMR();
        this.LoadJackaAttack();
        LoadJackaMove();
        LoadJackaDespawn();
    }

    protected virtual void LoadBossAnimator()
    {
        if (this.jackaAnimator != null) return;
        this.jackaAnimator = transform.GetComponentInChildren<JackaAnimator>();
        Debug.LogWarning(transform.name + ": LoadBossAnimator", gameObject);
    }

    protected virtual void LoadBossDMR()
    {
        if (this.jackaDMR != null) return;
        this.jackaDMR = transform.GetComponentInChildren<JackaDMR>();
        Debug.LogWarning(transform.name + ": LoadBossDMR", gameObject);
    }

    protected virtual void LoadJackaAttack()
    {
        if (this.jackaAttack != null) return;
        this.jackaAttack = transform.GetComponentInChildren<JackaAttack>();
        Debug.LogWarning(transform.name + ": LoadRandomAttack", gameObject);
    }

    protected virtual void LoadJackaMove()
    {
        if (this.jackaMove != null) return;
        this.jackaMove = transform.GetComponentInChildren<JackaMove>();
        Debug.LogWarning(transform.name + ": LoadJackaMove", gameObject);
    }

    protected virtual void LoadJackaStateController()
    {
        if (this.jackaState != null) return;
        this.jackaState = GetComponent<JackaStateController>();
        Debug.LogWarning(transform.name + ": LoadJackaStateController", gameObject);
    }

    protected virtual void LoadJackaDespawn()
    {
        if (this.jackaDespawn != null) return;
        this.jackaDespawn = transform.GetComponentInChildren<JackaDespawn>();
        Debug.LogWarning(transform.name + ": LoadJackaDespawn", gameObject);
    }
}
