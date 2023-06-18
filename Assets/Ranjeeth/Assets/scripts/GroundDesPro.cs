using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDesPro : MonoBehaviour
{
   
    private GameObject ground;
    private int groundColor;
    public int proColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = collision.gameObject;
            groundColor = ground.GetComponent<EnemyProjectileScript>().projectileColor;
            if((proColor +3)%6 == groundColor)
            {
                Destroy(ground);
            }



        }
    }



}
