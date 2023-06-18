using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryCannon : MonoBehaviour
{
    public float bulletforce = 5;
    public float firerate = 0.5f;
    public float mindist = 1;
     GameObject player;
    public GameObject projectile;
    public Transform cannon;
    private Vector2 target;
    private Vector2 line;
    Rigidbody2D rigidbody;
    private float timer ;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if( Vector2.Distance(player.transform.position , cannon.position ) <= mindist)
        {
             if(Input.GetMouseButton(0)&& timer > firerate)
        {
            //timer -= firerate;
            timer = 0;
             target = Camera.main.ScreenToWorldPoint( Input.mousePosition );
           
          
           line = -((Vector2)cannon.position - (Vector2)target)/(Vector2.Distance((Vector2)target,(Vector2)cannon.position));
            GameObject A =  Instantiate(projectile ,(Vector2)cannon.position + (Vector2)line*1.5f , Quaternion.identity ) ;
            rigidbody = A.GetComponent<Rigidbody2D>();
            rigidbody.velocity = (bulletforce*line);


            
        }
      //  else if (Input.GetMouseButtonUp(0))
        {


        }

        }
       
        

        
    }
}
