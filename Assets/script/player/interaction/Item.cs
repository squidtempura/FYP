using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType {NONE, PICKUP,EXAMINE}
    public InteractionType type;

    public KeyCode collectkey;
    
    public string item_description;

    public Text pickUpText;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 14;
    }

    public void Interact()
    {
        switch(type)
        {
            case InteractionType.PICKUP:
                if(Input.GetKeyDown(collectkey))
                {
                    FindObjectOfType<InventorySystem>().PickUp(gameObject);
                    gameObject.SetActive(false);
                    Debug.Log("pickup");
                }
                break;
            case InteractionType.EXAMINE:
                Debug.Log("examine");
                break;
            default:
                Debug.Log("null");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
           pickUpText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
           pickUpText.gameObject.SetActive(false);
        }
    }
}
