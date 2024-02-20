using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.player.AnimationData.fallParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.player.AnimationData.fallParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if(stateMachine.player.Controller.isGrounded) 
        {
            stateMachine.ChangeState(stateMachine.idleState);
            return;
        }
    }
}
