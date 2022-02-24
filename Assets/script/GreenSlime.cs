using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlime : MonoBehaviour
{
    public int health;
    public int damage;
    private PlayerHealth playerHealth;
    public GameObject dropCoin;    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
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
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Debug.Log(playerHealth);
            if(playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
        }
    }
}
