using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot1 : MonoBehaviour
{
    public float bulletforce = 5f;
    public GameObject boss;
    public float increment = 1;
    public GameObject projectile1;
    public GameObject projectile2;

    private float  k = 0;
    public float firerate = 0.5f;
    private Vector2 target;
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
        if(timer > firerate )
        {
            timer -= firerate;
            k += increment;
           
          target = new Vector2(Mathf.Cos(k*3.1415f/180.0f), Mathf.Sin(k*3.1415f/180.0f));
          if(BossBehaviour.currentColor == 1)
          {
             GameObject A =  Instantiate(projectile1 ,(Vector2)boss.transform.position + (Vector2)target * 7 , Quaternion.identity ) ;
            rigidbody = A.GetComponent<Rigidbody2D>();
           rigidbody.velocity  = (bulletforce*target );

          }
           if(BossBehaviour.currentColor == 4)
          {
             GameObject A =  Instantiate(projectile2 ,(Vector2)boss.transform.position + (Vector2)target * 7 , Quaternion.identity ) ;
            rigidbody = A.GetComponent<Rigidbody2D>();
           rigidbody.velocity  = (bulletforce*target );

          }
          




        }
       
        





        
    }
}
