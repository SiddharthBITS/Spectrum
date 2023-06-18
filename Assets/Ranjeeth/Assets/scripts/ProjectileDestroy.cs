using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
     {
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
