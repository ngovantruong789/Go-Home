using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : TruongMonoBehaviour
{
    [SerializeField] protected List<Transform> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }


    protected virtual void LoadPoints(){
        foreach(Transform point in transform){
            this.points.Add(point);
        }
    }

    public virtual Transform SpawmPointsOne(){
        return this.points[0];
    }

    public virtual Transform SpawmPointsTwo(){
        return this.points[1];
    }

    public virtual Transform SpawmPointsThree(){
        return this.points[2];
    }

    public virtual Transform SpawmPointsFour(){
        return this.points[3];
    }
}
