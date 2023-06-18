using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbBossMove : MonoBehaviour
{
    GameObject player;
    public float speed = 1f;
    Vector2 target;
    public Transform targetPos;



    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector2(targetPos.transform.position.x , targetPos.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position , target , speed);

    
        
    }
}
