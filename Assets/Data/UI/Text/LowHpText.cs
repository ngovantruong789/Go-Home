using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowHpText : BaseText
{
    protected override void OnEnable()
    {
        base.OnEnable();
        Invoke(nameof(SetActive), 2f);
    }

    public void SetActive()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
