using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
   public  GameObject wheelSound;
     //public int currentColor = 0;
    // public Transform[] loc;
    
     public static int BossHP = 20;
     public static int currentColor = 0;


     
    public Color32 black  = new Color32(0,   0,   0,   255);
    public Color32 red    = new Color32(255, 0,   0,   255);
    public Color32 orange = new Color32(255, 69,  0,   255);
    public Color32 yellow = new Color32(255, 255, 0,   255);
    public Color32 green  = new Color32(0,   255, 0,   255);
    public Color32 blue   = new Color32(0,   0,   255, 255);
    public Color32 purple = new Color32(128, 0,   128, 255);

    Color32[] colors = new Color32[7];
    //private float timer = 10;
    private float timer2 = 0;
    //public GameObject player;

    public float LocChangeTime= 5 ;
   // public float speed = 500;
   // public float speed2 = 100;
   // private Vector2 c ;
//private Vector2 d;
//    private int a;
    
    BossShoot1 script1;
    BossShoot2 script2;
    BossShoot3 script3;
    BossMovement script4;
    BossPhase2 script5;
    LineRenderer lr ;
    public float shoottime1 = 3;
    public float shoottime2 = 10;
    int z = 0;
    private bool inaction = false;
   // public Transform p2s;

    


    void Start()
    {
       //  b = new Vector2(transform.position.x,transform.position.y);
        colors[0] = black;
        colors[1] = red;
        colors[2] = orange;
        colors[3] = yellow;
        colors[4] = green;
        colors[5] = blue;
        colors[6] = purple;

        script1 = this.GetComponent<BossShoot1>();
        script2 = this.GetComponent<BossShoot2>();
        script3 = this.GetComponent<BossShoot3>();
        script4 = this.GetComponent<BossMovement>();
        script5 = this.GetComponent<BossPhase2>();
        lr = this.GetComponent<LineRenderer>();

        script1.enabled = false;
        script2.enabled = false;
        script3.enabled = false;
        script4.enabled = true;
        script5.enabled = false;
        lr.enabled = false;

        
        
        
    }

    void Update()
    {
        Debug.Log("BossHp : "+ BossHP);
        timer2 += Time.deltaTime;

        if(BossHP <=0)
        {
            //Destroy(this);
            script5.enabled = true;
             script1.enabled = false;
        script2.enabled = false;
        script3.enabled = false;
        script4.enabled = false;
        
            


        }
        
        if (currentColor >= 0 && currentColor <= 7)
        {
          //  if(script4.enabled == true)
            {
                gameObject.GetComponent<SpriteRenderer>().color = colors[currentColor];

            }
            //else
            {
                //gameObject.GetComponent<SpriteRenderer>().color = colors[BossLazer.bossColor];

            }
           
            
        }
       /* timer += Time.deltaTime;
        if(timer >= LocChangeTime)
        {
            timer -= LocChangeTime;
             a = Random.Range(0,6);
             b = new Vector2(loc[a].position.x , loc[a].position.y);
            

        }
        transform.position = Vector2.MoveTowards( transform.position, b , speed   * Time.deltaTime);
        if(a == 0 || a == 1 || a == 2)
        {
            currentColor = 4;
        }
        else if(a == 3 || a == 4 || a == 5)
        {
            currentColor = 1;
        }*/
        
        if(timer2 <= shoottime1)
        {
            wheelSound.SetActive(true);
            script1.enabled = true;

        }
        else if (timer2 > shoottime1 && timer2 <= shoottime2)
        {
            script1.enabled = false;
            wheelSound.SetActive(false);
            script2.enabled = true;

        }
        else if (timer2 > shoottime2)
        {
            script1.enabled = false;
            script2.enabled = false;
            timer2 -= shoottime2;

        }
            
        
        


    }
}
