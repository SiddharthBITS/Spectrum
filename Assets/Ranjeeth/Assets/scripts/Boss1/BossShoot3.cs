using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot3 : MonoBehaviour
{
    public float bulletforce = 5f;
    public int i = 5;
    public GameObject boss;
     GameObject player;
    public float firerate = 0.5f;
    
    public GameObject projectile1;
    public GameObject projectile2;
    
    
    
    private Vector2 target;
   
    
    private Rigidbody2D rigidbody;
     private float timer;
     public int max = 20;
     int a;
    
    int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {
         timer += Time.deltaTime;
        if(timer > firerate && a <= max )
        {
            target = player.transform.position - boss.transform.position;
             timer -= firerate;
             if(BossBehaviour.currentColor== 1)
             {
                  GameObject A =  Instantiate(projectile1 ,(Vector2)boss.transform.position , Quaternion.identity ) ;
          rigidbody = A.GetComponent<Rigidbody2D>();
         rigidbody.velocity  = (bulletforce*target );
         a++;

             }
             if(BossBehaviour.currentColor == 4)
             {
                  GameObject A =  Instantiate(projectile2 ,(Vector2)boss.transform.position , Quaternion.identity ) ;
          rigidbody = A.GetComponent<Rigidbody2D>();
         rigidbody.velocity  = (bulletforce*target );
         a++;

             }

            
           
        }
        
    }
}
