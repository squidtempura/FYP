using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine {get; private set;}

    public PlayerIdleState IdleState {get; private set;}
    public PlayerMoveState MoveState {get; private set;}
    public PlayerJumpState JumpState {get; private set;}
    public PlayerInAirState InAirState {get; private set;}
    public PlayerInLandState InLandState {get; private set;}
    public PlayerCrouchMoveState CrouchMoveState {get; private set;}
    public PlayerCrouchIdleState CrouchIdleState {get; private set;}
    public PlayerRunState RunState {get; private set;}
    #endregion

    [SerializeField]
    private PlayerData playerData;

    #region Components
    public Animator Anim {get; private set;}
    public PlayerInputHandler InputHandler {get; private set;}
    public Rigidbody2D rb {get; private set;}

    public CapsuleCollider2D cc2d {get; private set;}
    public PolygonCollider2D pc2d {get; private set;}
    
    #endregion

    #region Check Transforms
    [SerializeField]
    private Transform groundCheck;
    
    #endregion


    #region other variables
    public Vector2 CurrentVelocity {get; private set;}
    public int FacingDirection {get; private set;}
    
    private Vector2 workspace;
    #endregion

    #region Unity callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData,"isidle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData,"iswalk");
        JumpState = new PlayerJumpState(this, StateMachine,playerData,"isinair");
        InAirState = new PlayerInAirState(this,StateMachine, playerData, "isinair");
        InLandState = new PlayerInLandState(this,StateMachine,playerData,"isinland");
        CrouchMoveState = new PlayerCrouchMoveState(this,StateMachine,playerData,"iscrouchmove");
        CrouchIdleState = new PlayerCrouchIdleState(this,StateMachine,playerData,"iscrouchidle");
        RunState = new PlayerRunState(this,StateMachine,playerData,"isrun");

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        FacingDirection = 1;
        StateMachine.Initialize(IdleState);
        cc2d = GetComponent<CapsuleCollider2D>();
        pc2d = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        CurrentVelocity = rb.velocity;
        StateMachine.currentState.LogicUpdate();
    }

    private void FixedUpDate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }
    #endregion


    #region set Functions

    public void setVelocityZero()
    {
        rb.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x,velocity);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }
    #endregion

    #region check Functions 


    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,playerData.groundCheckRadius,playerData.whatIsGround);
    }
    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    #endregion

    #region other Functions

    public void SetColliderInvisible()
    {
        cc2d.enabled = false;
        pc2d.enabled = false;
    }
    public void SetColliderVisible()
    {
        cc2d.enabled = true;
        pc2d.enabled = true;
    }

    private void AnimationTrigger() => StateMachine.currentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.currentState.AnimationFinishTrigger();
    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion

}
