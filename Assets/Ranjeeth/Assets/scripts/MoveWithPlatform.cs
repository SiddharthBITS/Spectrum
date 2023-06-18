using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           other.collider.transform.SetParent(transform);

        }
        
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           other.collider.transform.SetParent(null);

        }

    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
