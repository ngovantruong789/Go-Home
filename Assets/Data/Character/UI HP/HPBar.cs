using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : BaseSlider
{
    [SerializeField] protected CharacterCtrl characterCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCharacterCtrl();
    }

    protected void LoadCharacterCtrl()
    {
        if (characterCtrl != null) return;
        characterCtrl = FindObjectOfType<CharacterCtrl>();
    }

    private void FixedUpdate()
    {
        SetValue();   
    }

    protected void SetValue()
    {
        if (characterCtrl == null) return;

        float hp = characterCtrl.CharacterDR.Hp;
        float hpMax = characterCtrl.CharacterDR.HpMax;

        slider.value = hp / hpMax;
    }
}
