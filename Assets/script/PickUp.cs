using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject inventoryitem;
  
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(inventoryitem,inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
