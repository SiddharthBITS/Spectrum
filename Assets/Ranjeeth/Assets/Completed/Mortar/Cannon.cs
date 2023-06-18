using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    //public Transform player;
    public int projectileColor;
    public GameObject a1;
    public GameObject a2;
    private float dist;
    public float shootDist;
    public GameObject projectile;
    public float fireRate;
    private float timer=0;
    public GameObject[] cannonBalls;
    private GameObject ABC;
    List<GameObject> balls = new List<GameObject>();
    [HideInInspector]
    public int numBalls  = 0;
    
    GameObject playerObject;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
      dist = Vector2.Distance(transform.position, playerObject.transform.position);

      if(dist <= shootDist)
      {
            a1.transform.position = new Vector2(playerObject.transform.position.x , a1.transform.position.y);
            a2.transform.position = new Vector2(playerObject.transform.position.x , a2.transform.position.y);

            fire();
      }
       void fire()
    {
      timer += Time.deltaTime;
      if (timer > fireRate && playerObject.GetComponent<ComplementaryChecker>().isComplementaryColor(projectileColor))
      {
        timer -= fireRate;
        ABC = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
      //  Destroy(ABC,2);
      }
      

    }
     
        
    }
    
   
}
