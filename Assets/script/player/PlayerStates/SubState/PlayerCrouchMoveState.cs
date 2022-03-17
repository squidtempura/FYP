using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchMoveState : PlayerGroundedState
{   
    public PlayerCrouchMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetColliderInvisible();
    }

    public override void Exit()
    {
        base.Exit();
        player.SetColliderVisible();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            player.SetVelocityX(playerData.crouchMoveVelocity * player.FacingDirection);
            player.CheckIfShouldFlip(xInput);
            Debug.Log(isTouchingCeilling);
            if(yInput != -1 && !isTouchingCeilling)
            {
                stateMachine.ChangeState(player.MoveState);
            }
        }
    }
}
