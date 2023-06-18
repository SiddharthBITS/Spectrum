using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPartol : MonoBehaviour

{

    public float walkSpeed;

    

    public bool mustPatrol;

    public Rigidbody2D rb;

    private bool mustTurn;
    

    public Transform groundCheckpos1;
    public Transform groundCheckpos2;
    public Collider2D bodyCollider;


    public LayerMask groundLayer;
    public LayerMask wallLayer;
    

    void Start()

    {

        mustPatrol = true;



    }



    void Update()

    {

        if (mustPatrol)

        {

            Patrol();

        }
       
       


    }

     void FixedUpdate()

    {

        if (mustPatrol)

        {

            mustTurn = !(Physics2D.OverlapCircle(groundCheckpos1.position, 1.2f, groundLayer)||  !Physics2D.OverlapCircle(groundCheckpos2.position, 1.2f, groundLayer));
           

        }

    }

    void Patrol(){

        if (mustTurn || bodyCollider.IsTouchingLayers(wallLayer))

        {

            Flip();

        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);

    }

    //Hàm lật Nhân vật
   
    void Flip()

    {

        mustPatrol = false;

        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        walkSpeed *= -1;

        mustPatrol = true;

    }

}