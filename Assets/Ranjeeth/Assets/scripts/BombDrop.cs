using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour
{
    public float range;
    public GameObject player;
    public float firerate = 1;
    public float timer = 0;
    public GameObject bomb;
        public Transform star;
    public float rangex;
    public float rangey;
    
    private Vector2 pos;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        pos = star.position;
        
        
    }

       void Update()
    {
        
        
        

        if(Vector2.Distance(player.transform.position, star.transform.position ) < range)
        {
            timer += Time.deltaTime;
            
            if(timer > firerate)
            {
                timer -= firerate;
                
             Vector2 pos1 = pos + new Vector2(Random.Range(-rangex/2,rangex/2),Random.Range(-rangey/2,rangey/2));

              Instantiate(bomb, pos1 , Quaternion.identity);

            }
           
        }
        
    }
    
   
    

  

}
