using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;

    protected bool isTouchingCeilling;

    protected bool RunInput;

    private bool JumpInput;
    private bool isGrounded;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.CheckIfGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
        player.JumpState.ResetAmountOfJumpsLeft();
    }
    
    public override void Exit()
    {
        base.Exit();
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormalInputX;
        yInput = player.InputHandler.NormalInputY;
        JumpInput = player.InputHandler.JumpInput;
        
        RunInput = player.InputHandler.RunInput;

        if(JumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        
        else if(!isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            player.JumpState.DecreaseAmountOfJumpsLeft();
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
