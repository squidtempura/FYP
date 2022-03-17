using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundedState
{
    public PlayerRunState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            player.SetVelocityX(playerData.runVelocity * player.FacingDirection);
            player.CheckIfShouldFlip(xInput);
            if(!RunInput)
            {
                stateMachine.ChangeState(player.MoveState);
            }
        }
    }
}
