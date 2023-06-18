using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot2 : MonoBehaviour
{
    public float bulletforce = 5f;
    public int i = 5;
    public GameObject boss;
    
    public GameObject projectile1;
    public GameObject projectile2;
    
    
    
    private Vector2 target;
    
    private Rigidbody2D rigidbody;
    
    int j = 0;
    private float timer= 0;
    
    public float firerate = 2f;
     
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       

        if(j >= i)
        {
            timer += Time.deltaTime;
            if(timer >= firerate )
         {
            j = 0 ;
            timer -= firerate;
         }
           
        }
        for(; j <i ; j++)
        {
            
            
           
          target = new Vector2(Mathf.Cos(j * 3.1415f *2 / i), Mathf.Sin(j * 3.1415f *2 / i));
          if(BossBehaviour.currentColor == 1)
          {
               GameObject A =  Instantiate(projectile1 ,(Vector2)boss.transform.position+ (Vector2)target*5 , Quaternion.identity ) ;
          rigidbody = A.GetComponent<Rigidbody2D>();
         rigidbody.velocity  = (bulletforce*target );

          }
          if(BossBehaviour.currentColor == 4)
          {
               GameObject A =  Instantiate(projectile2 ,(Vector2)boss.transform.position+ (Vector2)target*5 , Quaternion.identity ) ;
          rigidbody = A.GetComponent<Rigidbody2D>();
         rigidbody.velocity  = (bulletforce*target );

          }

        }

        
       
       
       
        





        
    }
}
