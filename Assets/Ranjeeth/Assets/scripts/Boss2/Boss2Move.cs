using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Move : MonoBehaviour
{
     GameObject player;
    public float speed = 50;
    public Transform c1;
    public Transform c2;
    public Transform c3;
    public Transform c4;
    public Transform c5;
    
    Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

        target = new Vector2(player.transform.position.x , player.transform.position.y);
        
        
            if(this.GetComponent<SpriteRenderer>().isVisible)
        {
            if(this.transform.position.x < c1.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position , target , speed*1.6f);

            }
            else if(this.transform.position.x >= c1.position.x && this.transform.position.x < c2.position.x )
            {
                 transform.position = Vector2.MoveTowards(transform.position , target , speed*2.5f);

            }
            else if(this.transform.position.x >= c2.position.x && this.transform.position.x < c3.position.x) 
            {
                transform.position = Vector2.MoveTowards(transform.position , target , speed*2.7f);

            }
            else if(this.transform.position.x >= c3.position.x && this.transform.position.x < c4.position.x) 
            {
                transform.position = Vector2.MoveTowards(transform.position , target , speed*2.5f);

            }
            else if(this.transform.position.x >= c4.position.x && this.transform.position.x < c5.position.x) 
            {
                transform.position = Vector2.MoveTowards(transform.position , target , speed*3f);

            }
            
            
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position , target , speed*15);
        }

        
        
        
        
        
        

        
    }
}
