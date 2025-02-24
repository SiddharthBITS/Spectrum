﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public GameObject PartEff;

    // Start is called before the first frame update
    void Start()
    {
     player =    GameObject.FindGameObjectWithTag("Player").transform;
     target = new Vector2(player.position.x , player.position.y);

    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards( transform.position, target , speed   * Time.deltaTime);
       if(transform.position.x == target.x && transform.position.y == target.y)
       {
               Instantiate(PartEff ,  transform.position, Quaternion.identity);

              Destroy(gameObject);
       }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Platforms" || col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
        {
            Instantiate(PartEff ,  transform.position, Quaternion.identity);
            Destroy(gameObject);
            
            
        }
    }
}
