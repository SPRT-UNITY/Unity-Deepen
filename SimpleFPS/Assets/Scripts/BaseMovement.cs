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
    public static Type createMovement<T>(EControlType controlType) where T : IControllable
    {
        if (controlType == EControlType.Grounded)
            return typeof(BaseMovement);
        return null;
    }
}

[RequireComponent(typeof(Rigidbody))]
public class BaseMovement : MonoBehaviour, IControllable
{
    Rigidbody rigidBody;

    Vector2 moveVector;
    Vector3 rotateToVector;

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
        gameObject.transform.rotation = Quaternion.LookRotation(lookVector);
    }


    public void RotateBy(Vector3 rotateVector)
    {
        Vector3 targetVector = transform.rotation.eulerAngles + Quaternion.LookRotation(rotateVector).eulerAngles;
        RotateTo(targetVector);
    }

    public void RotateTo(Vector3 targetVector) 
    {
        rotateToVector = targetVector.normalized;
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Lerp(gameObject.transform.forward, rotateToVector, Time.fixedDeltaTime * 1));
    }

    private void FixedUpdate()
    {
        if(moveVector != Vector2.zero) 
        {
            Move(moveVector);
        }
        if(rotateToVector != Vector3.zero)
        {
            RotateTo(rotateToVector);
        }
    }

}
