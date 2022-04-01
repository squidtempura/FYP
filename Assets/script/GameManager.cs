using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   private static GameManager instance;
   private Player player;

   public Vector3 respawnPoint;
  
   public int health;
   public int HealthMax;
   public Text healthText;
   

   private void Awake()
   {
       if(instance != null)
       {
           Destroy(gameObject);
           return;
       }

       instance = this;

       DontDestroyOnLoad(this);
   } 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    
        
        respawnPoint = player.transform.position;
        
        if(SaveManager.instance.hasLoaded)
        {
            respawnPoint = SaveManager.instance.activeSave.respawnPosition;
            player.transform.position = respawnPoint;
            health = SaveManager.instance.activeSave.health;
        }
        else
        {
            SaveManager.instance.activeSave.health = health;
        }
        healthText.text = health.ToString() + "/" + HealthMax.ToString();
        Debug.Log(healthText.text);
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        player.gameObject.SetActive(false);
        
        healthText.text = health.ToString() + "/" + HealthMax.ToString();
        
        SaveManager.instance.activeSave.health = health;

        yield return new WaitForSeconds(.5f);
        
        player.transform.position = respawnPoint;
        player.gameObject.SetActive(true);
    }
}
