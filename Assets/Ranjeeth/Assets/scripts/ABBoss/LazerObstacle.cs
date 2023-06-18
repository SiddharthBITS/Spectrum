using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LazerObstacle : MonoBehaviour
{
     public Color32 black  = new Color32(0,   0,   0,   255);
    public Color32 red    = new Color32(255, 0,   0,   255);
    public Color32 orange = new Color32(255, 69,  0,   255);
    public Color32 yellow = new Color32(255, 255, 0,   255);
    public Color32 green  = new Color32(0,   255, 0,   255);
    public Color32 blue   = new Color32(0,   0,   255, 255);
    public Color32 purple = new Color32(128, 0,   128, 255);
    Color32[] colors = new Color32[7];
    LineRenderer lr ;
    public float lazerDistance = 900;
    //float timer;
    public Transform LazerStart;
    public Transform LazerEnd;
    public int LazerColor;
    float timer = 0;
    public float switch1 = 1;
    public float switch2 = 1;
    float mag;
    public LayerMask abc;




   // public Transform a;
     GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        colors[0] = black;
        colors[1] = red;
        colors[2] = orange;
        colors[3] = yellow;
        colors[4] = green;
        colors[5] = blue;
        colors[6] = purple;
        lr = this.GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        lr.enabled = false;

        //mag = (LazerStart.position.x - LazerEnd.position.x , LazerStart.position.y - LazerEnd.position.y);

        //lazerDistance = Vector2.magnitude( Vector2(mag));
        
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetColors(colors[LazerColor], colors[LazerColor]);
        timer += Time.deltaTime;
        lr.SetPosition(0, new Vector3(LazerStart.position.x , LazerStart.position.y,0));             //changed
        //lr.SetPosition(1, new Vector2(LazerStart.position.x , LazerStart.position.y));
        if (timer >= switch1 && timer < (switch1+switch2))
        {
            lr.enabled = true;
            lr.SetPosition(1, new Vector3(LazerEnd.position.x  , LazerEnd.position.y,0));
             RaycastHit2D hit = Physics2D.Raycast(LazerStart.position ,transform.TransformDirection(Vector2.right)  , lazerDistance,abc);
            if(hit.collider.tag == "Player" && player.GetComponent<ComplementaryChecker>().isComplementaryColor(LazerColor))
            {
                //Destroy(player);
               // audio.enabled = true;
                player.GetComponent<ControllerScript>().playerHP--;
            // player.transform.position = Checkpoint.transform.position;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }



        }
        else if (timer > (switch1 + switch2))
        {
           // lazerSound.SetActive(false);
            timer -=(switch1+switch2);
            lr.SetPosition(1, new Vector3(LazerStart.position.x , LazerStart.position.y,0));
        }
        


        


        
    }
}
