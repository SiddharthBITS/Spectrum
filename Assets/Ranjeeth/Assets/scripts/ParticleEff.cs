using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEff : MonoBehaviour
{
  float timer2 = 0;
  //AudioSource audio;
    private GameObject player;
    public GameObject partEff;
    public GameObject projectile;
    
    private float timer=0;
    public float AliveTime;
    
    // Start is called before the first frame update
    void Start()
    {
      //audio = GetComponent<AudioSource>();
      player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
      //if(audio.enabled)
      //{
       // timer2 += Time.deltaTime;
      //{
        //if(timer2 >=2)
        //{
        //  timer-=2;
         // audio.enabled = false;

        //}
     // }

     // }
      
      
       
     timer += Time.deltaTime;
      if (timer > AliveTime)
      {
        //audio.enabled = true;

            timer -= AliveTime;
             Instantiate(partEff ,  projectile.transform.position, Quaternion.identity);
            Destroy(projectile);
      }
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Platforms" || col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
        {
         // audio.enabled = true;

            Instantiate(partEff ,  projectile.transform.position, Quaternion.identity);
            Destroy(projectile);
            
            
        }
    }
    


    
}
