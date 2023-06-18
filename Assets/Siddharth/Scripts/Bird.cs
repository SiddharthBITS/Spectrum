using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
     public BirdTrajectory trajectory;
    public float releaseTime;
    public float destroyTime;
    bool isClicked = false;
    bool isRelesased = false;
    public GameObject slingshot;
    public GameObject anchor;
    GameObject player;
    Rigidbody2D rb;
    int color;
    public Material[] colors;
    TrailRenderer trail;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        trail = gameObject.GetComponent<TrailRenderer>();
        trail.material = colors[player.GetComponent<ColourManager>().currentColor];
    }
    // Update is called once per frame
    void Update()
    {
        if(isClicked)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
    }


    private void OnMouseDown()
    {
        isClicked = true;
        Debug.Log("isClicked");
        rb.isKinematic = true;
        trajectory.Show();
    }
    private void OnMouseUp()
    {
        isClicked = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
        trajectory.Hide();
    }

    IEnumerator Release()
    {
        slingshot.GetComponent<SlingShot>().balls--;
        slingshot.GetComponent<SlingShot>().aBirdOnShot = false;
        isRelesased = true;
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        GetComponent<TrailRenderer>().enabled = true;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destroyTime);
        GetComponent<TrailRenderer>().enabled = false;
        slingshot.GetComponent<SlingShot>().aBirdOnShot = true;
        transform.position = anchor.transform.position;
        rb.velocity = new Vector2(0, 0);
        isRelesased = false;
        GetComponent<SpringJoint2D>().enabled = true;
        GetComponent<SpringJoint2D>().connectedBody = anchor.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        /*
        if (!isRelesased)
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<CircleCollider2D>());
        }
        */
        if(GetComponent<SpringJoint2D>().enabled)
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<CircleCollider2D>());
        }
        //if (collision.gameObject.tag == "Ground")
       // {
           //  GameObject.Destroy(collision.gameObject);
       // }
    }
}
