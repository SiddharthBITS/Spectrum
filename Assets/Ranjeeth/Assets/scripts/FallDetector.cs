using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
     GameObject player;
     GameObject Checkpoint;
     AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        Checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
        player = GameObject.FindGameObjectWithTag("Player");
        audio = player.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag == "Player") 
       {
            audio.enabled = true;
           
           player.GetComponent<ControllerScript>().playerHP--;
           player.transform.position = Checkpoint.transform.position;
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       

       }
    }
}
