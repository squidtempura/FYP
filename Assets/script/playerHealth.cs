using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameManager gm;
    public int health;
    public float hitBoxCdTime;
    private PolygonCollider2D pc2d;
    //private ScreenFlash sf;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //sf = GetComponent<ScreenFlash>();
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
        //if(health < 5)
        //{
        //    sf.FlashScreen();
        //}
        health -= damage;
        HealthBar.HealthCurrent = health;
        if(health <= 0)
        {
            health = 5;
            gm.Respawn();
        }
        else
        {
            StartCoroutine(ShowPlayerHitBox());
        }
        HealthBar.HealthCurrent = health;
        pc2d.enabled = false;
        //StartCoroutine(ShowPlayerHitBox());
    }

    public void HealPlayer(int heal)
    {
        health += heal;
        HealthBar.HealthCurrent = health;
        if(health > HealthBar.HealthMax)
        {
            health = HealthBar.HealthMax;
        }
        HealthBar.HealthCurrent = health;
        StartCoroutine(ShowPlayerHitBox());
    }

    IEnumerator ShowPlayerHitBox()
    {
        yield return new WaitForSeconds(hitBoxCdTime);
        pc2d.enabled = true;
    }

}
