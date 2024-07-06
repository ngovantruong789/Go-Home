using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFly : FireParentFly
{
    [SerializeField] protected Vector3 characterModel;
    [SerializeField] protected CharacterCtrl characterCtrl;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ModelPos();
        this.EffectMove();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterCtrl();
    }

    protected virtual void LoadCharacterCtrl()
    {
        if (this.characterCtrl != null) return;
        this.characterCtrl = Transform.FindObjectOfType<CharacterCtrl>();
        Debug.LogWarning(transform.name + ": LoadCharacterCtrl", gameObject);
    }

    protected virtual void ModelPos(){
        this.characterModel = characterCtrl.PlayPos.position;
    }
    protected virtual void EffectMove(){
        Vector3 objPos = transform.parent.position;
        direction = this.characterModel - objPos;
    }
}
