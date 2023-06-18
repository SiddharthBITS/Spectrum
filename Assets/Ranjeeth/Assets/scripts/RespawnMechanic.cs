using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMechanic : MonoBehaviour
{
   AudioSource audio;
    // GameObject Checkpoint;
    int HP;
    int startHP;
    GameObject player;
    float timer = 0;
   
    




    // Start is called before the first frame update
    void Start()
    {
       audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        startHP = player.GetComponent<ControllerScript>().playerHP;
       // Checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");

        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(startHP);
        
        HP = player.GetComponent<ControllerScript>().playerHP;
        if(HP == 0)
        {
           audio.enabled = true;


           // transform.position = Checkpoint.position;
           Destroy(player);
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
       // if(HP < startHP)
        //{
           // int a = startHP - HP;
            
           // player.transform.position = Checkpoint.transform.position;
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // startHP--;
            

      //  }
      if(audio.enabled)
      {
         timer += Time.deltaTime;
         if(timer >=2) 
         {
             audio.enabled = false;
             timer -=2;

         }
         
      }

        
    }
}
