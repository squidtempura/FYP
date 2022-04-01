using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    public float speed;
    public int damage;

    public float angle;
    public float destroyDistance;
    private Rigidbody2D rb2d;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(-5f,5f);
        //get component of the bullet object
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right*speed;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //bullet that exceed the range will be destroyed
        float distance = (transform.position- startPos).sqrMagnitude;
        Debug.Log(distance);
        if(distance > destroyDistance)
        {
            Destroy(gameObject); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
        {
            //if bullet is touching enemy
            if(other.gameObject.CompareTag("Enemy"))
            {
                //destroy bullet object
                Destroy(gameObject); 
                //bullet causes damage to enemy
                other.GetComponent<Enemy>().TakeDamage(damage);
                //other.GetComponent<GreenSlime>().TakeDamage(damage);
            }
        }
}
