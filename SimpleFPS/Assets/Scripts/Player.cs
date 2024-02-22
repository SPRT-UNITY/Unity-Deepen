using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public PlayerCharacterController possessedCharacterController { get; private set; }
    PlayerInput playerInput;
    Camera cam;

    public event Action<PlayerCharacterController> OnPossessed;
    public event Action OnUnPossessed;
    public event Action OnFire;

    private void Awake()
    {
        playerInput = gameObject.AddComponent<PlayerInput>();
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        OnPossessed += Possess;
        OnUnPossessed += UnPossess;

        if(possessedCharacterController == null) 
        {
            possessedCharacterController = FindObjectOfType<PlayerCharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    public void HandleInput() 
    {
        Vector2 moveVector = playerInput.PlayerActions.Move.ReadValue<Vector2>();
        possessedCharacterController.control.Move(moveVector);

        //Vector3 lookPosition = new Vector3();
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(playerInput.PlayerActions.Look.ReadValue<Vector2>());
        //if(Physics.Raycast(ray, out hit)) 
        //{
        //    lookPosition = hit.point;
        //}

        //Vector3 lookVector = lookPosition - possessedCharacterController.gameObject.transform.position;

        //possessedCharacterController.movement.Rotate(lookVector);

        Debug.Log(moveVector);

        possessedCharacterController.control.Look(new Vector3(moveVector.x, 0, moveVector.y));
    }

    void RegisterInput() 
    {

    }

    public void Possess(PlayerCharacterController characterController) 
    {
        if(possessedCharacterController != null) 
        {
            OnUnPossessed.Invoke();
        }
        possessedCharacterController = characterController;
    }

    public void UnPossess() 
    {
        possessedCharacterController = null;
    }
}
