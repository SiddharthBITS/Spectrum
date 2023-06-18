using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2 : MonoBehaviour
{
    public GameObject a;
     GameObject player;
    public float speed = 500;
    public float speed2 = 100;
    private Vector2 c ;
    private Vector2 d;
    private float timer;
    public GameObject cam;
    public Transform xcheck;
    public Transform campos;
    Vector2 pos;
    Vector3 target ;
    public float gravityMod = 4f;

    
    public Transform p2s;
    BossLazer script1;
    // Start is called before the first frame update
    void Start()
    {
        script1 = this.GetComponent<BossLazer>();
        script1.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        a.SetActive(false);
        if(player.transform.position.x >= xcheck.position.x)
        {
            target = new Vector3(campos.position.x , campos.position.y, -10);
             Vector3 smoothPosition = Vector3.Lerp(cam.transform.position , target , 0.1f);


            cam.transform.position = smoothPosition;
            //pos = new Vector2(campos.position.x , campos.position.y);
            //cam.transform.position = Vector2.MoveTowards( cam.transform.position, pos , 100   * Time.deltaTime);
            Physics2D.gravity = new Vector3(0, gravityMod );
           

        }
        timer += Time.deltaTime;
         c = new Vector2(p2s.position.x , p2s.position.y);
         d = new Vector2(p2s.position.x , player.transform.position.y +1 );
         if(timer <= 2)
         {
              transform.position = Vector2.MoveTowards( transform.position, c , speed   * Time.deltaTime);

         }
         
            
             

         
         if(timer > 2)
         {
             transform.position = Vector2.MoveTowards(transform.position ,d , speed2 *Time.deltaTime );

         }
         
         
         if((transform.position.x  == p2s.position.x))
         {
             script1.enabled = true;
         }
        
    }
}
