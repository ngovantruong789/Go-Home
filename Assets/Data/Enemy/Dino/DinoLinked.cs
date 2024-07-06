using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoLinked : TruongMonoBehaviour
{
    [SerializeField] protected DinoDMR dinoDMR;
    public DinoDMR DinoDMR => dinoDMR;
    [SerializeField] protected DinoMove dinoMove;
    public DinoMove DinoMove => dinoMove;

    [SerializeField] protected DinoShooting dinoShooting;
    public DinoShooting DinoShooting => dinoShooting;

    [SerializeField] protected DinoAnimator dinoAnimator;
    public DinoAnimator DinoAnimator => dinoAnimator;

    [SerializeField] protected DinoDespawn dinoDespawn;
    public DinoDespawn DinoDespawn => dinoDespawn;

    [SerializeField] protected DinoStateController dinoStateController;
    public DinoStateController DinoStateController => dinoStateController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDinoStateController();
        this.LoadDinoDMR();
        this.LoadDinoMove();
        this.LoadDinoShooting();
        LoadDinoDespawn();
        this.LoadDinoAnimator();
    }

    protected virtual void LoadDinoDMR()
    {
        if (this.dinoDMR != null) return;
        this.dinoDMR = transform.GetComponentInChildren<DinoDMR>();
        Debug.LogWarning(transform.name + "LoadMummyDMS", gameObject);
    }

    protected virtual void LoadDinoMove()
    {
        if (this.dinoMove != null) return;
        this.dinoMove = transform.GetComponentInChildren<DinoMove>();
        Debug.LogWarning(transform.name + "LoadDinoMove", gameObject);
    }

    protected virtual void LoadDinoShooting()
    {
        if (this.dinoShooting != null) return;
        this.dinoShooting = transform.GetComponentInChildren<DinoShooting>();
        Debug.LogWarning(transform.name + ": LoadDinoShooting", gameObject);
    }

    protected virtual void LoadDinoAnimator()
    {
        if (this.dinoAnimator != null) return;
        this.dinoAnimator = transform.GetComponentInChildren<DinoAnimator>();
        Debug.LogWarning(transform.name + ": LoadDinoAnimator", gameObject);
    }

    protected virtual void LoadDinoDespawn()
    {
        if (this.dinoDespawn != null) return;
        this.dinoDespawn = transform.GetComponentInChildren<DinoDespawn>();
        Debug.LogWarning(transform.name + ": LoadDinoDespawn", gameObject);
    }

    protected virtual void LoadDinoStateController()
    {
        if (this.dinoStateController != null) return;
        this.dinoStateController = transform.GetComponentInChildren<DinoStateController>();
        Debug.LogWarning(transform.name + ": LoadDinoStateController", gameObject);
    }
}
