using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : TruongMonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;
    [SerializeField] private Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos => mouseWorldPos;
    [SerializeField] private float onFiring;
    public float OnFiring => onFiring;
    
    protected override void Awake()
    {
        if(InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }

    void Update() {
        this.GetMouseDown();   
    }

    void FixedUpdate() {
        this.GetMousePos();    
    }

    protected virtual void GetMouseDown(){
        this.onFiring = Input.GetAxis("Fire1");
    }
    protected virtual void GetMousePos(){
        this.mouseWorldPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
