using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public Transform WeaponHolder;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
