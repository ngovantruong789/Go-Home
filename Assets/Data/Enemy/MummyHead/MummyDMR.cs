using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MummyDMR : DamgeReceiver
{
    [SerializeField] protected Rigidbody2D rigidbody2;
    [SerializeField] protected PolygonCollider2D colider2;
    [SerializeField] protected MummyCtrl mummyCtrl;
    [SerializeField] protected Animator animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigid();
        this.LoadMummyCtrl();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.CheckAnim();
    }
    protected virtual void LoadRigid(){
        if(this.rigidbody2 != null) return;
        this.rigidbody2 = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2.isKinematic = true;
         Debug.LogWarning(transform.name + "LoadRigid", gameObject);
    }

    protected virtual void LoadMummyCtrl(){
        if(this.mummyCtrl != null) return;
        this.mummyCtrl = transform.GetComponentInParent<MummyCtrl>();
         Debug.LogWarning(transform.name + "LoadMummyCtrl", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        CharacterImpact characterImpact = other.GetComponent<CharacterImpact>();
        if(characterImpact == null) return;

        this.mummyCtrl.MummyDMS.Send(other.transform);

        this.animator.SetBool("isCheckAttack", true);

        AudioManager.Instance.PlayAudio("Scratch");
    }

    protected virtual void CheckAnim(){
        this.animator.SetBool("isCheckAttack", false);
        this.animator.SetBool("isCheckDead", false);
    }

    protected override void OnDead()
    {
        this.mummyCtrl.MummyMove.Speed = 0;
        this.animator.SetBool("isCheckDead", true);
        this.colider2.enabled = false;
        Invoke(nameof(this.DespawnZeroHP), 0.5f);

        AudioManager.Instance.PlayAudio("MummyDeath");
        UIManager.Instance.SetPoint();
    }

    protected virtual void DespawnZeroHP(){
        this.mummyCtrl.MummyDespawn.DespawnObject();
        this.mummyCtrl.MummyMove.Speed = 4;
        this.colider2.enabled = true;
    }
}
