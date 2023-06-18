using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaaaaa : MonoBehaviour
{
    public float bulletforce = 5f;
    public int i = 5;
    public GameObject boss;
    
    public GameObject projectile;
    private float  k = 0;
    
    private Vector2 target;
    public float timeint= 0.2f;
    private float timer;
    private Rigidbody2D rigidbody;
     
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeint)
        {
            for(int j = 0; j <= i ; j++)
        {
            timer = 0;
            
            
           
          target = new Vector2(Mathf.Cos(j*2*3.1415f/i), Mathf.Sin(j*2*3.1415f/i));
          GameObject A =  Instantiate(projectile ,boss.transform.position , Quaternion.identity ) ;
          rigidbody = A.GetComponent<Rigidbody2D>();
         rigidbody.velocity  = (bulletforce*target );




        }

        }
       
        
       
        





        
    }
}
