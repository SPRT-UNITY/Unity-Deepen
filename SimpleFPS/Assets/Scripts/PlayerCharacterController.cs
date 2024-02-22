using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public IControllable control;
    EControlType controlType;

    public event Action<Vector2> OnMove;
    public event Action<Vector3> OnRotate;

    // to load Animator from modelObject;
    [SerializeField]
    GameObject modelObject;
    Animator animator;

    private void Awake()
    {
        if (control == null)
            control = gameObject.AddComponent<BaseMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = modelObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
