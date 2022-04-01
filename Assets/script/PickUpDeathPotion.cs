using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpDeathPotion : MonoBehaviour
{
    public int damage_value;
    private PlayerHealth playerHealth;
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            playerHealth.DamagePlayer(damage_value);
            Destroy(gameObject);
        }
    }
}
