using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputAction InputActions { get; private set; }

    public PlayerInputAction.PlayerActionMapActions PlayerActions { get { return InputActions.PlayerActionMap; } }

    private void Awake()
    {
        InputActions = new PlayerInputAction();
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayerActions.Enable();
    }

    private void OnDisable()
    {
        PlayerActions.Disable();
    }
}
