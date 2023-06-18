using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyProjectileScript : MonoBehaviour
{
    //float playerHP;
    public int projectileColor;
    GameObject player;
    GameObject Checkpoint;
    AudioSource audio;

    

    void Start()
    {
        
       // playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<ControllerScript>().playerHP;
       player = GameObject.FindGameObjectWithTag("Player");
       Checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
        audio = player.GetComponent<AudioSource>();
    }
        void Update()
    {
        if(player.GetComponent<ControllerScript>().playerHP <= 0)
        {
            Destroy(player);
        }
        

        
    }

     private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" &&  player.GetComponent<ComplementaryChecker>().isComplementaryColor(projectileColor))
        {
             audio.enabled = true;
            //GameObject.Destroy(collision.gameObject);
            player.GetComponent<ControllerScript>().playerHP--;
             player.transform.position = Checkpoint.transform.position;
             //audio.enabled = false;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        /*else if (collision.gameObject.tag == "Player" && player.GetComponent<ControllerScript>().playerHP == 2&&  player.GetComponent<ComplementaryChecker>().isComplementaryColor(projectileColor))
        {
            player.GetComponent<ControllerScript>().playerHP--;
        }*/

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" &&   player.GetComponent<ComplementaryChecker>().isComplementaryColor(projectileColor))
        {
             audio.enabled = true;
            //GameObject.Destroy(collision.gameObject);
            player.GetComponent<ControllerScript>().playerHP--;
             player.transform.position = Checkpoint.transform.position;
            // audio.enabled = false;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        /*else if (collision.gameObject.tag == "Player" &&  player.GetComponent<ControllerScript>().playerHP == 2&&  player.GetComponent<ComplementaryChecker>().isComplementaryColor(projectileColor))
        {
            player.GetComponent<ControllerScript>().playerHP--;
        }*/

    }
}
