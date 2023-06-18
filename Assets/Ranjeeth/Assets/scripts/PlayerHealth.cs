using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    private GameObject a;

   
    
    void OnCollisionEnter2D(Collision2D col)
    {
      
        if(col.gameObject.tag=="enemy" )
        {
            
           health --;
           a = col.gameObject;
           Destroy(a);

        }

     }
     
    
    void Update()
    {
       if( health <= 0)
       {
            Destroy(gameObject);
       }
        
    }
}
