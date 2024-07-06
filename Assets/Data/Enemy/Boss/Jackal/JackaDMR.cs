using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JackaDMR : DamgeReceiver
{
    [SerializeField] protected Rigidbody2D rigidbody2;
    [SerializeField] protected PolygonCollider2D polygonCollider2;

    [SerializeField] protected JackaCtrl jackaCtrl;
    public JackaCtrl JackaCtrl => jackaCtrl;

    [SerializeField] protected LowHpText lowHpText;

    [SerializeField] protected bool isLowHp;
    public bool IsLowHP => isLowHp;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigid();
        LoadCollider();
        this.LoadBossCtrl();
        LoadLowText();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetValue();

        EnemySpawnerRandom enemySpawner = FindObjectOfType<EnemySpawnerRandom>();
        enemySpawner.SetIsStop(true);
    }
    protected virtual void LoadCollider()
    {
        if (this.polygonCollider2 != null) return;
        this.polygonCollider2 = transform.GetComponent<PolygonCollider2D>();
        polygonCollider2.isTrigger = true;
        Debug.LogWarning(transform.name + ": LoadRigid", gameObject);
    }

    protected virtual void LoadRigid()
    {
        if (this.rigidbody2 != null) return;
        this.rigidbody2 = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadRigid", gameObject);
    }

    protected virtual void LoadBossCtrl()
    {
        if (this.jackaCtrl != null) return;
        this.jackaCtrl = transform.GetComponentInParent<JackaCtrl>();
        Debug.LogWarning(transform.name + ": LoadBossCtrl", gameObject);
    }

    protected void LoadLowText()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        lowHpText = canvas.transform.Find("LowHpText").GetComponent<LowHpText>();
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        if (hp <= hpMax / 2)
        {
            LowHp();
            isLowHp = true;
        }
    }

    protected void LowHp()
    {
        if (isLowHp) return;
        EnemySpawnerRandom enemySpawner = FindObjectOfType<EnemySpawnerRandom>();
        enemySpawner.SetIsStop(false);
        lowHpText.SetActive();
    }

    protected override void OnDead()
    {
        //if (isDead) return;
        this.polygonCollider2.enabled = false;
        Invoke(nameof(this.DespawnObj), 1.5f);

        jackaCtrl.JackaAnimator.SetActiveChildren(false);
        jackaCtrl.JackaAnimator.SetTriggerParameter("Tr_Dead");
        TimePlayManager.Instance.Dead = true;
        AudioManager.Instance.PlayAudio("BossDead");
        UIManager.Instance.SetPoint();
        GameLevelManager.Instance.LevelUp();

        BgMovement bgMovement = FindObjectOfType<BgMovement>();
        bgMovement.SetIsStop(false);
    }

    protected virtual void DespawnObj()
    {
        this.jackaCtrl.JackaDespawn.DespawnObject();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.polygonCollider2.enabled = true;
        isLowHp = false;
    }
}
