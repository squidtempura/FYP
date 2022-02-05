using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    private playerHealth playerHealth;
    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            playerHealth.DamagePlayer(damage);
        }
    }
}
