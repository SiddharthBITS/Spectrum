using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochet_Movement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.AddForce(speed * direction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
