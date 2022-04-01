using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpHealthPotion : MonoBehaviour
{
    public int heal_value;
    private PlayerHealth playerHealth;
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            playerHealth.HealPlayer(heal_value);
            Destroy(gameObject);
        }
    }
}
