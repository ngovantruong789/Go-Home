using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDAttack : TruongMonoBehaviour
{
    [SerializeField] protected DDCtrl dDCtrl;
    [SerializeField] protected Transform prefabGround;
    [SerializeField] protected Vector3 posGround = new Vector3(-0.11f, -0.42f);
    [SerializeField] protected float timerAttack;
    public float TimerAttack => timerAttack;

    [SerializeField] protected bool isAttack;
    public bool IsAttack => isAttack;

    protected override void OnEnable()
    {
        base.OnEnable();
        SpawnGround();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        ResetValue();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDDCtrl();
    }

    protected virtual void LoadDDCtrl()
    {
        if (this.dDCtrl != null) return;
        this.dDCtrl = transform.GetComponentInParent<DDCtrl>();
        Debug.Log(transform.name + ": LoadDDCtrl", gameObject);
    }

    protected void SpawnGround()
    {
        Transform prefab = AttackSpawner.Instance.Spawn("Ground", transform.parent.position, Quaternion.identity);
        prefab.SetParent(transform);
        prefab.position = new Vector3(prefab.position.x + posGround.x, prefab.position.y + posGround.y);

        GroundCtrl groundCtrl = prefab.GetComponent<GroundCtrl>();
        groundCtrl.GroundDMS.ActionPhysics(false, false);

        prefab.gameObject.SetActive(true);
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(timerAttack);
        bool isDead = dDCtrl.DungDropperDMR.IsDead;
        if(isDead)
        {
            float timerDespawnMax = dDCtrl.DDMove.TimerDespawnMax;
            Invoke(nameof(ResetGround), timerDespawnMax - 1);
            yield break;
        }

        dDCtrl.DDAnimator.SetTriggerLeftHand();
        dDCtrl.DDAnimator.SetTriggerParameter("Tr_Attack");
        GroundCtrl groundCtrl = transform.GetComponentInChildren<GroundCtrl>();
        groundCtrl.ResetParent();
        groundCtrl.GroundDMS.ActionPhysics(true, true);
        isAttack = true;

        dDCtrl.DDMove.SetSpeedMove(dDCtrl.DDMove.SpeedMove - 1);
        dDCtrl.DDMove.SetMoveDirection(Vector3.up);
        dDCtrl.DDMove.isStop = false;
    }

    public void ResetGround()
    {
        GroundCtrl groundCtrl = transform.GetComponentInChildren<GroundCtrl>();
        if (groundCtrl == null) return;
        groundCtrl.ResetParent();
        groundCtrl.GroundDMS.ActionPhysics(false, false);
        groundCtrl.GroundDespawn.DespawnObject();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        isAttack = false;
    }
}
