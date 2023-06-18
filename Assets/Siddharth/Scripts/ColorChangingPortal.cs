using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingPortal : MonoBehaviour
{
    private GameObject player;
    public float triggerDistance = 0.25f;
    public int portalColor;
    AudioSource audio;
    float timer = 0;
    void Start()
    {
        audio = GetComponent<AudioSource>();

       player = GameObject.FindGameObjectWithTag("Player");
       if( audio.enabled)
       {
           timer += Time.deltaTime;
           if(timer >=2)
           {
                audio.enabled = false;
                timer -=2;

           }
       }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(! (player.GetComponent<ColourManager>().currentColor == portalColor))
            {
                 audio.enabled = true; 

            }
                     
             player.GetComponent<ColourManager>().currentColor = portalColor;
        }
    }
   
}
