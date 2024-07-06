using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : TruongMonoBehaviour
{
    private static PointManager instance;
    public static PointManager Instance => instance;

    [SerializeField] protected ObjCountPointCtrl objCountPointCtrl;
    public ObjCountPointCtrl ObjCountPointCtrl => objCountPointCtrl;

    [SerializeField] protected int point = 0;
    public int Point { get => point; set => point = value; }

    protected override void Awake()
    {
        base.Awake();
        if(PointManager.instance != null) Debug.LogError("Only 1 PointManager allow to exist");
        PointManager.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjCountPointCtrl();
    }

    protected virtual void LoadObjCountPointCtrl()
    {
        if (this.objCountPointCtrl != null) return;
        this.objCountPointCtrl = FindObjectOfType<ObjCountPointCtrl>();
        Debug.LogWarning(transform.name + ": LoadObjCountPointCtrl", gameObject);
    }

    public virtual void AddPoint()
    {
        this.point += 1;
        this.objCountPointCtrl.CheckPoint(this.point);
    }
}
