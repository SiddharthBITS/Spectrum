using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    //public static int currentColor = 0;
    public Transform[] loc;
    public Color32 black  = new Color32(0,   0,   0,   255);
    public Color32 red    = new Color32(255, 0,   0,   255);
    public Color32 orange = new Color32(255, 69,  0,   255);
    public Color32 yellow = new Color32(255, 255, 0,   255);
    public Color32 green  = new Color32(0,   255, 0,   255);
    public Color32 blue   = new Color32(0,   0,   255, 255);
    public Color32 purple = new Color32(128, 0,   128, 255);
    Color32[] colors = new Color32[7];
    private float timer = 10;
     public float LocChangeTime= 5 ;
    public float speed = 5;
    private Vector2 b ;
    private int a;
    // Start is called before the first frame update
    void Start()
    {
         b = new Vector2(transform.position.x,transform.position.y);
        colors[0] = black;
        colors[1] = red;
        colors[2] = orange;
        colors[3] = yellow;
        colors[4] = green;
        colors[5] = blue;
        colors[6] = purple;

        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= LocChangeTime)
        {
            timer -= LocChangeTime;
             a = Random.Range(0,6);
             b = new Vector2(loc[a].position.x , loc[a].position.y);
            

        }
        transform.position = Vector2.MoveTowards( transform.position, b , speed   * Time.deltaTime);
        if(a == 0 || a == 1 || a == 2)
        {
            BossBehaviour.currentColor = 4;
        }
        else if(a == 3 || a == 4 || a == 5)
        {
            BossBehaviour.currentColor = 1;
        }
        
    }
}
