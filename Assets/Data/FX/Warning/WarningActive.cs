using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningActive : TruongMonoBehaviour
{
    [SerializeField] protected Transform modelWarning;

    [SerializeField] protected WarningCtrl warningCtrl;
    public WarningCtrl WarningCtrl => warningCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModelWarning();
        this.LoadWarningCtrl();
    }

    protected override void Start()
    {
        base.Start();
        this.DisableModelWarning();
    }
    protected virtual void LoadModelWarning()
    {
        if (this.modelWarning != null) return;
        this.modelWarning = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModelWarning", gameObject);
    }

    protected virtual void LoadWarningCtrl()
    {
        if (this.warningCtrl != null) return;
        this.warningCtrl = transform.GetComponentInParent<WarningCtrl>();
        Debug.LogWarning(transform.name + ": LoadWarningCtrl", gameObject);
    }

    public virtual void DisableModelWarning()
    {
        this.modelWarning.gameObject.SetActive(false);
        AudioManager.Instance.StopAudio("Warning");
    }

    public virtual void EnableModelWarning()
    {
        AudioManager.Instance.PlayAudio("Warning");
        this.modelWarning.gameObject.SetActive(true);
        Invoke(nameof(this.DisableModelWarning), 2.5f);
    }
}
