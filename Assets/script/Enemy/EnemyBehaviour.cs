using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject GreenSlimeBehaviour;
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2d;

    Animator actionAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        actionAnimator = GreenSlimeBehaviour.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position,player.position);
        
        if(distToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing player
            StopChasingPlayer();
        }
    }

    private void ChasePlayer()
    {
        
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed,0);
            transform.localScale = new Vector2(1,1);
            
        }
        else if(transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed,0);
            transform.localScale = new Vector2(-1,1);
        }
    }

    private void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0,0);
    }
}
