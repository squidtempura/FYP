using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        health -= damage;
        HealthBar.HealthCurrent = health;
        if(health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
        HealthBar.HealthCurrent = health;
    }
}
