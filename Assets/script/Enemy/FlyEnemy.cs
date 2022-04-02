using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    public float speed, circleRadius;
    private Rigidbody2D EnemyRB;
    public GameObject rightcheck, roofcheck, groundcheck;
    public LayerMask groundLayer;
    private bool facingRight = true, groundTouch, roofTouch, righttouch;
    public float dirX = 1, dirY = 0.25f;
    private PlayerHealth playerHealth;
    
    // Start is called before the first frame update
    public void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        EnemyRB.velocity = new Vector2(dirX, dirY) * speed *Time.deltaTime;
        HitDetection();
    }

    void HitDetection()
    {
        righttouch = Physics2D.OverlapCircle(rightcheck.transform.position, circleRadius, groundLayer);
        roofTouch = Physics2D.OverlapCircle(roofcheck.transform.position,circleRadius,groundLayer);
        groundTouch = Physics2D.OverlapCircle(groundcheck.transform.position,circleRadius, groundLayer);
        HitLogic();
    }

    void HitLogic()
    {
        if(righttouch && facingRight)
        {
            Flip();
        }
        else if(righttouch && !facingRight)
        {
            Flip();
        }
        if(roofTouch)
        {
            dirY = -0.25f;
        }
        else if(groundTouch)
        {
            dirY = 0.25f;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0,180,0));
        dirX = -dirX;   
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rightcheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(roofcheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(groundcheck.transform.position, circleRadius);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if(playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
        }
    }
}
