using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ObjCountPointCtrl : TruongMonoBehaviour
{
    [SerializeField] protected int limitPoint = 0;

    [SerializeField] protected bool checkStopSpawn = false;
    public bool CheckStopSpawn => checkStopSpawn;

    public virtual void CheckPoint(int point)
    {
        if(point >= this.limitPoint) StopSpawn();
    }

    public virtual void StopSpawn()
    {
        this.checkStopSpawn = true;
    }
}
