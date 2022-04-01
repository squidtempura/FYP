using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretbullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int damage;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            playerHealth.DamagePlayer(damage);
            Destroy(gameObject);
        }
    }
}
