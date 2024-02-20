using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStateMachine : StateMachine
{
    public Player player { get; }

    public PlayerIdleState idleState { get; }
    public PlayerWalkState walkState { get; }

    public PlayerRunState runState { get; }

    public PlayerAirState airState { get; }
    public PlayerFallState fallState { get; }
    public PlayerJumpState jumpState { get; }

    public PlayerComboAttackState comboAttackState { get; }

    public Vector2 MovementInput { get; set; }

    public float MovementSpeed { get; private set; }

    public float RotationDamping { get; private set; }

    public float MovementSpeedModifier { get; set; } = 1.0f;

    public float JumpForce { get; set; }

    public bool IsAttacking { get; set; }

    public int ComboIndex { get; set; }

    public Transform MainCameraTransform { get; set; }

    public PlayerStateMachine(Player player) 
    {
        this.player = player;

        idleState = new PlayerIdleState(this);
        walkState = new PlayerWalkState(this);
        runState = new PlayerRunState(this);
        airState = new PlayerAirState(this);
        fallState = new PlayerFallState(this);
        jumpState = new PlayerJumpState(this);
        comboAttackState = new PlayerComboAttackState(this);

        MainCameraTransform = Camera.main.transform;

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
    }
}
