using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public int damage;
    public float time;
    public float startTime;
    private Animator playerAnim;
    private PolygonCollider2D coll2D;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(Input.GetButtonDown("attack"))
        {
            coll2D.enabled = true;
            playerAnim.SetTrigger("attack");
            StartCoroutine(startAttack());
        }
    }

    IEnumerator startAttack()
    {
        yield return new WaitForSeconds(startTime);
        coll2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<GreenSlime>().TakeDamage(damage);
        }
    }
        
}
