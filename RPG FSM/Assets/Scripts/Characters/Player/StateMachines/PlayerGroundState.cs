using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.player.AnimationData.GroundParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.player.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();

        
        if(stateMachine.IsAttacking)
        {
            OnAttack();
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!stateMachine.player.Controller.isGrounded
            && stateMachine.player.Controller.velocity.y < Physics.gravity.y * Time.fixedDeltaTime)
        {
            stateMachine.ChangeState(stateMachine.fallState);
            return;
        }
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context) 
    {
        if (stateMachine.MovementInput == Vector2.zero)
            return;

        stateMachine.ChangeState(stateMachine.idleState);

        base.OnMovementCanceled(context);
    }

    protected override void OnJumpStarted(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.jumpState);
        base.OnJumpStarted(context);
    }

    protected virtual void OnMove()
    {
        stateMachine.ChangeState(stateMachine.walkState);
    }

    protected virtual void OnAttack() 
    {
        stateMachine.ChangeState(stateMachine.comboAttackState);
    }
}
