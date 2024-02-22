using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable 
{
    public void Move(Vector2 moveVector);
    public void RotateBy(Vector3 rotateVector);

    public void RotateTo(Vector3 rotateVector);

    public void Look(Vector3 lookVector);
}

[Serializable]
public enum EControlType 
{
    Grounded, Floating, Specato
}

public static class MovementFactory 
{
    public static IControllable createMovement(EControlType controlType) 
    {
        if (controlType == EControlType.Grounded)
            return new BaseMovement();
        return null;
    }
}

[RequireComponent(typeof(Rigidbody))]
public class BaseMovement : MonoBehaviour, IControllable
{
    Rigidbody rigidBody;

    Vector2 moveVector;
    Vector3 rotateVector;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rigidBody.freezeRotation = true;
    }

    public void Move(Vector2 moveVector) 
    {
        rigidBody.velocity = new Vector3(moveVector.x, 0, moveVector.y);
    }


    public void Look(Vector3 lookVector) 
    {
        gameObject.transform.forward = lookVector;
    }


    public void RotateBy(Vector3 rotateVector)
    {
        rigidBody.MoveRotation(Quaternion.Euler(rotateVector));
    }

    public void RotateTo(Vector3 targetVector) 
    {

    }

    private void FixedUpdate()
    {
        if(moveVector != Vector2.zero) 
        {
            Move(moveVector);
        }
        if(rotateVector != Vector3.zero)
        {
            RotateTo(rotateVector);
        }
    }

}
