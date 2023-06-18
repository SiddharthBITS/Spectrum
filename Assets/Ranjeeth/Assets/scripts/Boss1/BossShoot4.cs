using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot4 : MonoBehaviour
{
    public float bulletforce = 5f;
    public GameObject boss;
    public float increment = 1;
    public GameObject projectile;
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
        if(timer > firerate && k <= 1080)
        {
            timer -= firerate;
            k += increment;
           
          target = new Vector2(Mathf.Cos(k*3.1415f/180.0f), Mathf.Sin(k*3.1415f/180.0f));
          GameObject A =  Instantiate(projectile ,(Vector2)boss.transform.position + (Vector2)target * 5 , Quaternion.identity ) ;
          rigidbody = A.GetComponent<Rigidbody2D>();
         rigidbody.velocity  = (bulletforce*target );




        }
       
        





        
    }
}
