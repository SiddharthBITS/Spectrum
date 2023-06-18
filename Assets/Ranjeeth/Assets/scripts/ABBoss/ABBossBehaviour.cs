using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABBossBehaviour : MonoBehaviour
{
    public static int BossHP = 20;
     public static int currentColor = 2;
      GameObject player;
     private int playerColor;
     public float colorSwitchTime =2f;
     float timer ;
     private int a;
bool z = true;




     
    public Color32 black  = new Color32(0,   0,   0,   255);
    public Color32 red    = new Color32(255, 0,   0,   255);
    public Color32 orange = new Color32(255, 69,  0,   255);
    public Color32 yellow = new Color32(255, 255, 0,   255);
    public Color32 green  = new Color32(0,   255, 0,   255);
    public Color32 blue   = new Color32(0,   0,   255, 255);
    public Color32 purple = new Color32(128, 0,   128, 255);

    Color32[] colors = new Color32[7];
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        colors[0] = black;
        colors[1] = red;
        colors[2] = orange;
        colors[3] = yellow;
        colors[4] = green;
        colors[5] = blue;
        colors[6] = purple;
        gameObject.GetComponent<SpriteRenderer>().color = colors[currentColor];

        
    }

    // Update is called once per frame
    void Update()
    {
        

        /* if (currentColor >= 0 && currentColor <= 7)
        {
         
            {
                gameObject.GetComponent<SpriteRenderer>().color = colors[currentColor];

            }
            playerColor = player.GetComponent<ColourManager>().currentColor;
            if( playerColor == 3)
            {
                currentColor = 6;

            }
            else
            {
                currentColor = (playerColor + 3)%6 ; 
            }

           
           
            
        }*/
        //colorSwitchTime = Random.Range(4,6);
        timer += Time.deltaTime;
        if(timer >= colorSwitchTime && z)
        {
            timer -= colorSwitchTime;
            currentColor = 5;
            gameObject.GetComponent<SpriteRenderer>().color = colors[5];
             z = false;


        }
        if(timer >= colorSwitchTime && !z)
        {
            timer -= colorSwitchTime;
            currentColor = 2;
            gameObject.GetComponent<SpriteRenderer>().color = colors[2];
             z = true;


        }



        
    }
}
