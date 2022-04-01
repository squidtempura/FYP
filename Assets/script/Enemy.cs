using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public GameObject[] dropItem;
    private int itemIndex;
    private int totalItemsInArray = 0;

    // Start is called before the first frame update
    public void Start()
    {
        foreach(GameObject item in dropItem)
        {
            totalItemsInArray++;
        }
        itemIndex = Random.Range(0, totalItemsInArray);
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0)
        {
            Debug.Log(itemIndex);
            Instantiate(dropItem[itemIndex], transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
