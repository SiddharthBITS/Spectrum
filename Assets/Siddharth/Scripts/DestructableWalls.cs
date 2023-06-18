using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWalls : MonoBehaviour
{
    int platformColor;
     GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        platformColor = this.GetComponent<EnemyProjectileScript>().projectileColor;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Bullet" && player.GetComponent<ComplementaryChecker>().isComplementaryColor(platformColor))
        {
            Destroy(gameObject);
            

        }
        
    }

}
