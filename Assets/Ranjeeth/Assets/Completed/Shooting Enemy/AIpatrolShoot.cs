using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIpatrolShoot : MonoBehaviour

{
    AudioSource audio;
    [SerializeField] private Transform healthbar = null;
    public float walkSpeed;
   // public float Pspeed = 100f;
    public float firerate = 1f;

    public float range;
    private float timer;
    public int projectileColor;
    

    public bool mustPatrol;

    public Rigidbody2D rb;

    private Vector2 shootdir;

    private bool mustTurn;
    private float distToPlayer;
    public GameObject projectile;

    public Transform groundCheckpos1;
    public Transform groundCheckpos2;
    public Collider2D bodyCollider;


    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private GameObject player;
    private Vector2 dir;
    private float angle;
    
    public 

    void Start()
    {
         audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        mustPatrol = true;
    }



    void Update()

    {
         dir = (Vector2)player.transform.position - (Vector2)transform.position;
         angle =  Mathf. Atan2(dir. y,dir. x) * Mathf. Rad2Deg;

        if (mustPatrol)

        {

            Patrol();

        }
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distToPlayer >= range)
        {
            mustPatrol = true;

        }
        if(distToPlayer <= range)
        {
             audio.enabled = true;

            //shootdir = new Vector2(player.transform.position.x, player.transform.position.y);
            if(player.transform.position.x > transform.position.x && transform.localScale.x < 0 || player.transform.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
            mustPatrol = false;
           var  heading = player.transform.position - transform.position;
           var distance = heading.magnitude;
           var direction = heading/ distance;

             timer += Time.deltaTime;
             if(timer > firerate && GameObject.FindGameObjectWithTag("Player").GetComponent<ComplementaryChecker>().isComplementaryColor(projectileColor))
            {
                timer -=firerate;
                Instantiate(projectile,(Vector2)transform.position + (Vector2)direction*1, Quaternion.AngleAxis(angle-90, Vector3. forward));
                //Rigidbody2D rigidbody2d = projectile.GetComponent<Rigidbody2D>();
               // rigidbody2d.velocity = shootdir * Time.deltaTime * Pspeed;
              // projectile.transform.position = Vector2.MoveTowards(projectile.transform.position,shootdir, Pspeed* Time.deltaTime );

             }
        }
        else
        {
             audio.enabled = false;

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

    
    
    void Flip()

    {

        mustPatrol = false;

        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        healthbar.localScale = new Vector2(healthbar.localScale.x * -1, healthbar.localScale.y);

        walkSpeed *= -1;

        mustPatrol = true;

    }

}
