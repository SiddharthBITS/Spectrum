using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingOrb : MonoBehaviour
{
    GameObject player;
    float timer;
    
    public int orbColor;
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");
         if(!gameObject.activeSelf)
         {
             timer += Time.deltaTime;
             if(timer >= 2)
             {
                 timer -= 2;
                 gameObject.SetActive(true);
                 

             }

         }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<ColourManager>().currentColor = orbColor;
            gameObject.SetActive(false);
        }
    }
}
