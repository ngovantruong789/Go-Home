using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : TruongMonoBehaviour
{
    [SerializeField] protected CharacterImpact characterImpact;
    public CharacterImpact CharacterImpact => characterImpact;

    [SerializeField] protected BulletImpact bulletImpact;
    public BulletImpact BulletImpact => bulletImpact;

    [SerializeField] protected CharacterDR characterDR;
    public CharacterDR CharacterDR => characterDR;

    [SerializeField] protected Transform playPos;
    public Transform PlayPos => playPos;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCharacterDR();
        this.LoadBulletImpact();
    }
    protected virtual void LoadBulletImpact(){
        if(this.bulletImpact != null) return;
        this.bulletImpact = transform.GetComponentInChildren<BulletImpact>();
        Debug.LogWarning(transform.name + ": LoadBulletImpact", gameObject);
    }

    protected virtual void LoadCharacterDR()
    {
        if (this.characterDR != null) return;
        this.characterDR = transform.GetComponentInChildren<CharacterDR>();
        Debug.LogWarning(transform.name + ": LoadCharacterDR", gameObject);
    }
}
