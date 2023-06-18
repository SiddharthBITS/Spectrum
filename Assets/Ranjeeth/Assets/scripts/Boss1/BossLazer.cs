using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLazer : MonoBehaviour
{
    public GameObject lazerSound;
    AudioSource audio;
     GameObject Checkpoint;
    public Color32 black  = new Color32(0,   0,   0,   255);
    public Color32 red    = new Color32(255, 0,   0,   255);
    public Color32 orange = new Color32(255, 69,  0,   255);
    public Color32 yellow = new Color32(255, 255, 0,   255);
    public Color32 green  = new Color32(0,   255, 0,   255);
    public Color32 blue   = new Color32(0,   0,   255, 255);
    public Color32 purple = new Color32(128, 0,   128, 255);
    Color32[] colors = new Color32[7];
    LineRenderer lr ;
    public float lazerDistance = 900f;
    public Transform a;
     GameObject player;
    public static int bossColor;
    private float timer1 = 0;
    private float timer2 = 0;
    public float switch1 = 2;
    public float switch2 = 3;
    public Transform p;
    public LayerMask abc;
    float timer;

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
        lr.enabled = true;
        player = GameObject.FindGameObjectWithTag("Player");
        Checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
         audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<ColourManager>().currentColor == 3)
        {
            //lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.SetColors(colors[6], colors[6]);
            BossBehaviour.currentColor = 6;
        
        }
        else if(player.GetComponent<ColourManager>().currentColor == 6)
        {
           // lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.SetColors(colors[3], colors[3]);
            BossBehaviour.currentColor = 3;

        }
       
        timer1 += Time.deltaTime;
        lr.SetPosition(0, new Vector2(transform.position.x , transform.position.y));
        lr.SetPosition(1, new Vector2(transform.position.x , transform.position.y));
        if(timer1> switch1 && timer1 < (switch1+switch2)&& transform.position.x == a.position.x)
        {
            lazerSound.SetActive(true);
            lr.SetPosition(1, new Vector3(transform.position.x - lazerDistance , transform.position.y,0));
            RaycastHit2D hit = Physics2D.Raycast(transform.position ,transform.TransformDirection(Vector2.left)  , lazerDistance,abc);
            if(hit.collider.tag == "Player")
            {
                //Destroy(player);
                audio.enabled = true;
                player.GetComponent<ControllerScript>().playerHP--;
             player.transform.position = Checkpoint.transform.position;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }
          // if( (player.transform.position.y - transform.position.y)  <= 0.1 &&  (p.position.x - player.transform.position.x) <= lazerDistance  )
           //{
              // Destroy(player);

          // }

        }
        else if(timer1 > (switch1 + switch2))
        {
            lazerSound.SetActive(false);
            timer1 -=(switch1+switch2);
            lr.SetPosition(1, new Vector3(transform.position.x , transform.position.y,0));
        }
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
