using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public Transform WeaponHolder;
  
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(WeaponHolder.gameObject.transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Gun"))
        {
            other.gameObject.transform.parent = WeaponHolder;
            other.gameObject.transform.position = WeaponHolder.position;
            if(other.gameObject.transform.parent.transform.childCount == 2)
            {
                other.gameObject.transform.gameObject.SetActive(false);
            } 
        }
        
    }
}
