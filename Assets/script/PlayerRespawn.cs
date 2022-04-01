using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRespawn : MonoBehaviour
{
    private GameManager gm;
    private PlayerHealth Health;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        //transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health == null)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gm.Respawn();
        }
    }
}
