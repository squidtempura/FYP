using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float walkspeed;
    public float jumpspeed;
    public float doublejumpspeed;
    public bool isOnGround; 
    public bool canDoubleJump;
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerFeet;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Flip();
        Jump();
        
        CheckOnGround();
        SwitchAnimation();
    }

    void Walk()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir*walkspeed,playerRigidbody.velocity.y);
        playerRigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > 0;
        playerAnim.SetBool("iswalk",playerHasXAxisSpeed);
    }

    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > 0;
        if(playerHasXAxisSpeed)
        {
            if(playerRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);
            }

            
            if(playerRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(isOnGround)
            {
                playerAnim.SetBool("isjump",true);
                Vector2 jumpVel = new Vector2(0.0f, jumpspeed);
                playerRigidbody.velocity = Vector2.up * jumpVel;
                canDoubleJump = true;
            }
            else
            {
                if(canDoubleJump)
                {
                    playerAnim.SetBool("doublejump",true);
                    Vector2 DoubleJumpVel = new Vector2(0.0f,doublejumpspeed);
                    playerRigidbody.velocity = Vector2.up*DoubleJumpVel;
                    canDoubleJump = false;
                }
            }
        }
    }

    void CheckOnGround()
    {
        isOnGround = playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log(isOnGround);
    }

    void SwitchAnimation()
    { 
        playerAnim.SetBool("isidle",false);
        if(playerAnim.GetBool("isjump"))
        {
            if(playerRigidbody.velocity.y < 0.0f)
            {
                playerAnim.SetBool("isjump",false);
                playerAnim.SetBool("isfall",true);
            }
        }
        else if(isOnGround)
        {
            playerAnim.SetBool("isfall",false);
            playerAnim.SetBool("isidle",true);
        }
        if(playerAnim.GetBool("doublejump"))
        {
            if(playerRigidbody.velocity.y < 0.0f)
            {
                playerAnim.SetBool("doublejump",false);
                playerAnim.SetBool("doublefall",true);
            }
        }
        else if(isOnGround)
        {
            playerAnim.SetBool("doublefall",false);
            playerAnim.SetBool("isidle",true);
        }
    }
}
