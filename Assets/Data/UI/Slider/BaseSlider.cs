using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSlider : TruongMonoBehaviour
{
    [Header("Base Slider")]
    [SerializeField] protected Slider slider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSlider();
    }

    protected void LoadSlider()
    {
        if (slider != null) return;
        slider = GetComponent<Slider>();
    }
}
