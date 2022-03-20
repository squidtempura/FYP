using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    [Header("UI items section")]
    public GameObject ui_window;
    public Image[] items_images;
    [Header("UI item description")]
    public GameObject ui_description_window;
    public Text description_title;
    public Text description_text;

    public void PickUp(GameObject item)
    {
        items.Add(item);
        Update_UI();
    }

    void Update_UI()
    {
        for(int i = 0; i < items.Count; i++)
        {
            Debug.Log(i);
            items_images[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void ShowDescription(int id)
    {
        description_title.text = items[id].name;
        description_text.text = items[id].GetComponent<Item>().item_description;
        ui_description_window.SetActive(true);
        description_title.gameObject.SetActive(true);
        description_text.gameObject.SetActive(true);
    }

    public void HideDescription()
    {
        ui_description_window.SetActive(false);
        description_title.gameObject.SetActive(false);
        description_text.gameObject.SetActive(false);
    }
}
