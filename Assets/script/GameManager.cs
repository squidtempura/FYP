using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   static GameManager instance;

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

   public static void PlayerDied()
   {
        instance.Invoke("RestartScene",1.5f);
   }

   void RestartScene()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}