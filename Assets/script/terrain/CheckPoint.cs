using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager gm;
    //public GameObject checkPoint;
    public GameObject checkPointLight;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            checkPointLight.GetComponent<SpriteRenderer>().color = Color.green;
            gm.respawnPoint = transform.position;
            SaveManager.instance.activeSave.respawnPosition = transform.position;
            SaveManager.instance.Save();
        }    
    }
}
