using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlSpike : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private bool groundDetected;
    [SerializeField]
    private bool wallDetected;
    [SerializeField]
    private Transform groundPositionChecker;
    [SerializeField]
    private Transform wallPositionChecker;
    [SerializeField]
    private float groundCheckDistance;
    [SerializeField]
    private float wallCheckDistance;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool hasTurn;
    private float ZaxieAdd;
    private int Direction;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        hasTurn = false;
        Direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CheckGroundOrWall();
        Movement();
    }

    void CheckGroundOrWall()
    {
        groundDetected = Physics2D.Raycast(groundPositionChecker.position,-transform.up,groundCheckDistance,whatIsGround);
        wallDetected = Physics2D.Raycast(wallPositionChecker.position,transform.right,wallCheckDistance,whatIsGround);
        if(!groundDetected)
        {
            if(hasTurn == false)
            {
                ZaxieAdd -= 90;
                transform.eulerAngles = new Vector3(0,0,ZaxieAdd);
                if(Direction == 1)
                {
                    transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y - 0.2f);
                    hasTurn = true;
                    Direction = 2;
                }
                else if(Direction == 2)
                {
                    transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y - 0.2f);
                    hasTurn = true;
                    Direction = 3;
                }
                else if(Direction == 3)
                {
                    transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y + 0.2f);
                    hasTurn = true;
                    Direction = 4;
                }
                else if(Direction == 4)
                {
                    transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.2f);
                    hasTurn = true;
                    Direction = 1;
                }
                
            }
        }
        if(groundDetected)
        {
            hasTurn = false;
        }

        if(wallDetected)
        {
            if(hasTurn == false)
            {
                ZaxieAdd += 90;
                transform.eulerAngles = new Vector3(0,0,ZaxieAdd);
                if(Direction == 1)
                {
                    transform.position = new Vector2(transform.position.x - 0.4f,transform.position.y + 0.2f);
                    hasTurn = true;
                    Direction = 4;
                }
                else if(Direction == 2)
                {
                    transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.2f);
                    hasTurn = true;
                    Direction = 1;
                }
                else if(Direction == 3)
                {
                    transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y - 0.2f);
                    hasTurn = true;
                    Direction = 2;
                }
                else if(Direction == 4)
                {
                    transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y -0.2f);
                    hasTurn = true;
                    Direction = 3;
                }
            }
        }
    }

    void Movement()
    {
        rb2d.velocity = transform.right * 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundPositionChecker.position, new Vector2(groundPositionChecker.position.x,groundPositionChecker.position.y-groundCheckDistance));
        Gizmos.DrawLine(wallPositionChecker.position, new Vector2(wallPositionChecker.position.x + wallCheckDistance, wallPositionChecker.position.y));
    }
}
