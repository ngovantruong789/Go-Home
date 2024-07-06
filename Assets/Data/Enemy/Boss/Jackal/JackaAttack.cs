using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackaAttack : TruongMonoBehaviour
{
    [SerializeField] protected JackaCtrl jackaCtrl;
    
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeLimit = 0f;
    [SerializeField] protected float timerAttack;

    [SerializeField] protected int randAttack = 0;
    public int RandAttack => randAttack;

    [SerializeField] protected bool isAttack;
    public bool IsAttack => isAttack;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJackaCtrl();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetValue();
    }

    protected virtual void LoadJackaCtrl()
    {
        if (this.jackaCtrl != null) return;
        this.jackaCtrl = transform.GetComponentInParent<JackaCtrl>();
        Debug.LogWarning(transform.name + ": LoadJackaCtrl", gameObject);
    }

    protected int RandomAttack()
    {
        return Random.Range(1, 3);
    }

    public void OnAttack()
    {
        if (CheckMove()) return;
        if (isAttack) return;
        timer -= Time.fixedDeltaTime;
        if (timer > 0) return;
        timer = timeLimit;

        isAttack = true;
        randAttack = RandomAttack();
        if(randAttack == 1)
            jackaCtrl.JackaAnimator.JackaHeadCtrl.JackaHeadState.ChangeState(new JackaHeadAttackState(jackaCtrl));
        else jackaCtrl.JackaAnimator.JackaHeadCtrl.JackaHeadState.ChangeState(new JackaFireAttackState(jackaCtrl));
    }

    public IEnumerator HeadAttack()
    {
        AudioManager.Instance.PlayAudio("SkeletonAttack");
        yield return new WaitForSeconds(timerAttack);
        jackaCtrl.JackaAnimator.SetActiveHead(false);
        Vector3 pos = jackaCtrl.JackaAnimator.JackaHeadCtrl.transform.position;
        Transform prefab = AttackSpawner.Instance.Spawn("Head", pos, Quaternion.identity);
        prefab.gameObject.SetActive(true);
        AudioManager.Instance.PlayAudio("Wing");
    }

    public IEnumerator FireAttack()
    {
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
        yield return new WaitForSeconds(timerAttack);
        Vector3 pos = EnemySpawnPoints.Instance.GetPosByName("Fire2SpawnPoint");
        Transform prefab = AttackSpawner.Instance.Spawn("Fire_2", pos, Quaternion.identity);
        prefab.gameObject.SetActive(true);
    }

    public void SetAttack(bool isAttack)
    {
        this.isAttack = isAttack;
    }

    protected bool CheckMove()
    {
        return jackaCtrl.JackaMove.IsMove;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        timer = timeLimit / 2;
        this.isAttack = false;
    }
}
