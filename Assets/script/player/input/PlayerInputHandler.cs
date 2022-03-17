using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput {get; private set; }
    public int NormalInputX {get; private set;}
    public int NormalInputY {get; private set;}
    public bool JumpInput {get; private set;}
    public bool RunInput {get; private set;}

    [SerializeField]
    private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;

    private void Update() 
    {
        CheckJumpInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        if(Mathf.Abs(RawMovementInput.x) > 0.5f)
        {
            NormalInputX = (int)(RawMovementInput*Vector2.right).normalized.x;
        }
        else
        {
            NormalInputX = 0;
        }
        if(Mathf.Abs(RawMovementInput.y) > 0.5f)
        {
            NormalInputY = (int)(RawMovementInput*Vector2.up).normalized.y;
        }
        else 
        {
            NormalInputY = 0;
        }
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            JumpInput = true;
            jumpInputStartTime = Time.time;
        }
    }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            RunInput = true;
        }
        if(context.canceled)
        {
            RunInput = false;
        }
    }


    public void UseJumpInput() => JumpInput = false;
    
    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
}
