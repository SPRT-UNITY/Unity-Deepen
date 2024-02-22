using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable 
{
    public void Move(Vector2 moveVector);
    public void Rotate(Vector3 rotateVector);

    public void Look(Vector3 lookVector);
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
        gameObject.transform.LookAt(lookVector);
    }

    public void Rotate(Vector3 rotateVector) 
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
            rigidBody.MovePosition(moveVector);
        }
        if(rotateVector != Vector3.zero)
        {
            rigidBody.MoveRotation(Quaternion.Euler(rotateVector));
        }
    }
}
