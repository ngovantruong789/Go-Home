using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureMove : TruongMonoBehaviour
{
    [SerializeField] protected VultureCtrl vultureCtrl;
    public VultureCtrl VultureCtrl => vultureCtrl;

    [SerializeField] protected float speed = 0f;
    public float Speed { get => speed; set => speed = value; }

    [SerializeField] protected Vector3 objPos = Vector3.left;

    [SerializeField] protected float timerChangeMove;
    [SerializeField] protected bool checkMove = false;
    public bool CheckMove => checkMove;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadVultureCtrl();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetValue();
        Invoke(nameof(this.RandomMove), timerChangeMove);
    }

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void LoadVultureCtrl()
    {
        if (this.vultureCtrl != null) return;
        this.vultureCtrl = transform.GetComponentInParent<VultureCtrl>();
        Debug.LogWarning(transform.name + ": LoadVultureCtrl", gameObject);
    }

    protected virtual void Moving()
    {
        if (this.vultureCtrl.VultureDMR.Check) {
            this.objPos = Vector3.down;
            this.objPos = new Vector3(this.objPos.x - 1, this.objPos.y, 0);
            this.vultureCtrl.VultureDMR.Check = false;
        }
        transform.parent.Translate(this.objPos * this.speed * Time.fixedDeltaTime);
    }
    
    public virtual void  RandomMove()
    {
        int rand = Random.Range(1, 3);
        if (rand != 1) this.ChangeMove();
    }


    protected virtual void ChangeMove()
    {
        AudioManager.Instance.PlayAudio("Wing");

        if (this.vultureCtrl.VultureDMR.Hp < 1) return;
        this.speed = 0.5f;
        this.vultureCtrl.VultureAnimator.Enable();
        vultureCtrl.VultureDMR.Hp = vultureCtrl.VultureDMR.Hp / 2;
        vultureCtrl.VultureDMS.SetDamageAttack();
        Vector3 characterPos = this.vultureCtrl.CharacterCtrl.PlayPos.position;
        //Vector3 parentPos = transform.parent.position;

        this.objPos = characterPos - transform.parent.position;

        this.checkMove = true;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 4f;
        this.objPos = Vector3.left;
        this.checkMove = false;
    }
}
