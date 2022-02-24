using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    private playerHealth pHealth;
    public GameObject dropCoin; 
    // Start is called before the first frame update
    public void Start()
    {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0)
        {
            Instantiate(dropCoin, transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D" )
        {
            if(pHealth != null)
            {
                pHealth.DamagePlayer(damage);
            }
        }
    }
}


