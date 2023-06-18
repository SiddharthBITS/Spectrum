using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject AOE;
    private Vector2 loc;
    private GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Ground")
        {
            loc = new Vector2(gameObject.transform.position.x ,gameObject.transform.position.y );    
            Destroy(gameObject);
            spawn = (GameObject)Instantiate(AOE, loc , Quaternion.identity );
            Destroy(spawn,3);
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
