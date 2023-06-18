using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public GameObject player;
    public int portalColor;
    ComplementaryChecker script;
    
   
    public GameObject portalB;
    Rigidbody2D rb ;
    //bool a;
    Vector2 dir;
    Vector2 offset;
    private float timer;
    public float reset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        script = player.GetComponent<ComplementaryChecker>();
        //a = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        dir =new Vector2 (rb.velocity.x , rb.velocity.y);
        offset = new Vector2(dir.x / dir.magnitude, dir.y / dir.magnitude) ;
        //if(!a)
        //{
           // timer += Time.deltaTime;
            //if(timer>= reset)
            //{
               // timer -= reset;
                //a = true;

            //}
           
        //}
        

        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && script.isSameColor(portalColor)  )
        {
            player.transform.position = new Vector2(portalB.transform.position.x + offset.x*2, portalB.transform.position.y + offset.y*2) ;
            

        }
    }
    
}
