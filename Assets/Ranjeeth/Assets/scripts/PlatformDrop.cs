using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDrop : MonoBehaviour
{
   // public GameObject player;
    Rigidbody2D rb;
    public float dropTime = 1f; 
        void Start()
    {
       rb  = GetComponent<Rigidbody2D>();
        

        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Invoke("DropPlat", dropTime);
        }

    }
    void DropPlat()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1;
    }
}
