using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float walkspeed;
    public float runspeed;
    public float jumpspeed;
    public float slidespeed;
    public float doublejumpspeed;
    public bool isOnGround; 
    public bool canDoubleJump;
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerFeet;
    private PolygonCollider2D pc2D;
    private CapsuleCollider2D cc2D;
    private Animator playerAnim;

    public float time;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        //get components of player object
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerFeet = GetComponent<BoxCollider2D>();
        pc2D = GetComponent<PolygonCollider2D>();
        cc2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Run();
        Slide();
        Flip();
        Jump();
        
        CheckOnGround();

        SwitchAnimation();
    }

    void Walk()
    {
        playerAnim.SetBool("isrun",false);
        playerAnim.SetBool("isslide",false);
        //get user input
        float moveDir = Input.GetAxis("Horizontal");
        //calculate velocity value of player, has speed in x direction, 0 in y direction
        Vector2 playerVel = new Vector2(moveDir*walkspeed,playerRigidbody.velocity.y);
        //assign value to the velocity attribute
        playerRigidbody.velocity = playerVel;
        //boolean variable to detect player has speed in x direction
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > 0;
        //if it is true, update character state to iswalk
        playerAnim.SetBool("iswalk",playerHasXAxisSpeed);
    }

    void Run()
    {
        //boolean variable to detect player has speed in x direction
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > 0;
        if(playerAnim.GetBool("iswalk") && !playerAnim.GetBool("isjump") && !playerAnim.GetBool("isfall"))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                //get user input
                float moveDir = Input.GetAxis("Horizontal");
                //calculate velocity value of player, has speed in x direction, 0 in y direction
                Vector2 playerVel = new Vector2(moveDir*runspeed,playerRigidbody.velocity.y);
                //assign value to the velocity attribute
                playerRigidbody.velocity = playerVel;
                //if it is true, update character state to iswalk
                playerAnim.SetBool("isrun",playerHasXAxisSpeed);
            }
        }
    }

    void Slide()
    {
        //boolean variable to detect player has speed in x direction
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > 0;
        if(playerAnim.GetBool("iswalk") && !playerAnim.GetBool("isjump") && !playerAnim.GetBool("isfall"))
        {
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                pc2D.enabled = false;
                cc2D.enabled = false;
                //if it is true, update character state to iswalk 
                playerAnim.SetBool("isslide",true);
                walkspeed = slidespeed;
                StartCoroutine(startSlide());
            }
        }
    }

    IEnumerator startSlide()
    {
        yield return new WaitForSeconds(startTime);
        pc2D.enabled = false;
        cc2D.enabled = false;
        walkspeed = slidespeed;
        StartCoroutine(disableHitBox());
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        pc2D.enabled = true;
        cc2D.enabled = true;
        walkspeed = 8;
    }

    void Flip()
    {
        //detect player has speed in x direction
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > 0;
        //if has speed
        if(playerHasXAxisSpeed)
        {
            //if player moves to the right
            if(playerRigidbody.velocity.x > 0.1f)
            {
                //character face right
                transform.localRotation = Quaternion.Euler(0,0,0);
            }

            //if player moves to the left
            if(playerRigidbody.velocity.x < -0.1f)
            {
                //character flip 180 degrees, the character will face left
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
        }
    }

    void Jump()
    {
        //if user press jump button
        if(Input.GetButtonDown("Jump"))
        {
            //check character is on the ground
            if(isOnGround)
            {
                //update transition condition
                playerAnim.SetBool("isjump",true);
                //calculate velocity value of player, x direction 0, y direction has speed
                Vector2 jumpVel = new Vector2(0.0f, jumpspeed);
                //assign the value to the velocity
                playerRigidbody.velocity = Vector2.up * jumpVel;
                //update transition condition
                canDoubleJump = true;
            }
            else
            {
                // same as jump
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
        //check if the collider of characters feet is touching ground layer
        isOnGround = playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))||
                     playerFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"));
        
    }

    void resetCollider()
    {
        pc2D.enabled = true;
        cc2D.enabled = true;
    }

    // play different animation according to the character state
    void SwitchAnimation()
    { 
        //when character is not idle
        playerAnim.SetBool("isidle",false);
        // if is jumping
        if(playerAnim.GetBool("isjump"))
        {
            playerAnim.SetBool("iswalk",false);
            // if speed of y direction is less than 0
            if(playerRigidbody.velocity.y < 0.0f)
            {
                //character is falling
                playerAnim.SetBool("isjump",false);
                playerAnim.SetBool("isfall",true);
            }
        }
        //if is on the ground
        else if(isOnGround)
        {
            //character is no longer falling
            playerAnim.SetBool("isfall",false);
            playerAnim.SetBool("isidle",true);
        }
        //if character can double jump
        if(playerAnim.GetBool("doublejump"))
        {
            // speed of y direction is less than 0
            if(playerRigidbody.velocity.y < 0.0f)
            {
                //character is falling
                playerAnim.SetBool("doublejump",false);
                playerAnim.SetBool("doublefall",true);
            }
        }
        //if character is on the ground
        else if(isOnGround)
        {
            //character is no longer double falling
            playerAnim.SetBool("doublefall",false);
            playerAnim.SetBool("isidle",true);
        }

        if(!isOnGround)
        {
            playerAnim.SetBool("iswalk",false);
            playerAnim.SetBool("isidle",false);
        }


    }
}
