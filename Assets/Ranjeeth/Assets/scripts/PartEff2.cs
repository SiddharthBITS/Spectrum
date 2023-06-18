using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartEff2 : MonoBehaviour
{
    private GameObject player;
    public GameObject partEff;
    public GameObject projectile;
    
    
    
   public float distance;
   
    
    // Start is called before the first frame update
    void Start()
    {
      
      player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {

      
       
     
      if (Vector2.Distance(this.transform.position , player.transform.position)> distance)
      {
          
             Instantiate(partEff ,  projectile.transform.position, Quaternion.identity);
            Destroy(projectile);

      }
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Platforms" || col.gameObject.tag == "Ground" || col.gameObject.tag == "Boss" )
        {
            Instantiate(partEff ,  projectile.transform.position, Quaternion.identity);
            Destroy(projectile);
            
            
        }
        
    }
    
}

