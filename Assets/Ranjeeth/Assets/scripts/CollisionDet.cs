﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDet : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "ground")
       {
              Destroy(gameObject);
       }

    }
}
