using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.JumpForce = stateMachine.player.Data.AirData.JumpForce;
        stateMachine.player.forceReceiver.Jump(stateMachine.JumpForce);
        base.Enter();
        StartAnimation(stateMachine.player.AnimationData.JumpParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.player.AnimationData.JumpParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.Update();

        if (stateMachine.player.Controller.velocity.y <= 0.0f)
        {
            stateMachine.ChangeState(stateMachine.fallState);
            return;
        }
    }
}
