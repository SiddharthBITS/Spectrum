using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{


    private GameObject player;
    public GameObject SniperEnemy;
    public Transform calculateAngleWith;
    public float rangeOfRaycast = 50f;
    public float angularRange;
    public int lightColor;
    public float angle;
    public float angle2;

    private float dist;
    float timer = 0;
    private float dist2;
    public float range = 9;
    public LayerMask a = 12;
    AudioSource audio;

    void Start()
    {
        audio = GetComponentInParent<AudioSource>();
        SniperEnemy = GameObject.FindGameObjectWithTag("SniperEnemy");
         player = GameObject.FindGameObjectWithTag("Player");
        angle = Vector2.Angle(transform.position - player.transform.position, transform.position - calculateAngleWith.position);
        angle2 = Vector2.Angle(transform.position - SniperEnemy.transform.position, transform.position - calculateAngleWith.position);
    }
    void Update()
    {
        angle = Vector2.Angle(transform.position - player.transform.position, transform.position - calculateAngleWith.position);
        angle2 = Vector2.Angle(transform.position - SniperEnemy.transform.position, transform.position - calculateAngleWith.position);
        dist = Vector2.Distance(transform.position , player.transform.position);
        dist2 = Vector2.Distance(transform.position , SniperEnemy.transform.position);
        if( audio.enabled)
       {
           timer += Time.deltaTime;
           if(timer >=0.5f)
           {
                audio.enabled = false;
                timer -=0.5f;

           }
       }

    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, a);
        if(hit.collider.CompareTag("Player") && angle < angularRange && dist< range)
        {
             if(player.GetComponent<ColourManager>().currentColor != lightColor)
            {
                 audio.enabled = true;

            }
            Debug.Log("CHeck");
            player.GetComponent<ColourManager>().currentColor = lightColor;
           
            
        }

        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, SniperEnemy.transform.position - transform.position, Mathf.Infinity, a);

        /*if(hit2.collider != null)
        {
             Debug.Log(hit2.collider.tag);



        }*/

        if(hit2.collider.CompareTag("SniperEnemy") && angle2 < angularRange && dist2< range)
        {
            Debug.Log("CHeck");
            //SniperEnemy = hit.collider.gameObject;
            if(lightColor != 6)
            {
                SniperEnemy.GetComponent<SniperEnemy>().enemyColor = lightColor;

            }
            else
            {
                SniperEnemy.GetComponent<SniperEnemy>().enemyColor = 0;


            }  
        }
        
        
    }
}
