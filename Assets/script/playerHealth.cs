using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public float hitBoxCdTime;
    private PolygonCollider2D pc2d;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
        pc2d = GetComponent<PolygonCollider2D>();
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
            GameManager.PlayerDied();
        }
        HealthBar.HealthCurrent = health;
        pc2d.enabled = false;
        StartCoroutine(ShowPlayerHitBox());
    }

    IEnumerator ShowPlayerHitBox()
    {
        yield return new WaitForSeconds(hitBoxCdTime);
        pc2d.enabled = true;
    }
}
