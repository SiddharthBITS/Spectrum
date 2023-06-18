using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleScript : MonoBehaviour
{
    public GameObject player;
    private GameObject point;
    private int pointColor;
    ComplementaryChecker script;

    DistanceJoint2D joint;
    ControllerScript movementScript;
    new Rigidbody2D rigidbody;
    LineRenderer rope;
    public float distance = 10.0f, maxSpeed = 8.0f;
    [SerializeField] LayerMask grappleLayerMask;
    bool notGrappled = true;
    public float speed;
    RaycastHit2D raycastHit;
    BoxCollider2D boxCollider;

    public bool grappleEnabled = true;

    private void Start()
    {
        script = player.GetComponent<ComplementaryChecker>();
        joint = GetComponent<DistanceJoint2D>();
        movementScript = GetComponent<ControllerScript>();
        rigidbody = GetComponent<Rigidbody2D>();
        rope = GetComponent<LineRenderer>();
        boxCollider = player.GetComponent<BoxCollider2D>();
        joint.enabled = false;
        rope.enabled = false;
    }

    private void Update()
    {
        if (grappleEnabled)
        {
            if (rigidbody.transform.position.y - raycastHit.point.y > 0)
            {
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            }

            rope.SetPosition(0, transform.position);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;

                raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(8, 20), 0f, Vector2.up, 0.1f, grappleLayerMask);
                //raycastHit = Physics2D.Raycast(transform.position, mousePos - transform.position, distance, grappleLayerMask);

                point = raycastHit.collider.gameObject;
                pointColor = point.GetComponent<GrappelPoint>().color;

                if (notGrappled)
                {
                    Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);

                    if (raycastHit.collider != null && raycastHit.collider.gameObject.GetComponent<Rigidbody2D>() != null && (Vector2.Distance(transform.position, raycastHit.point)) > 2 && (script.isSameColor(pointColor)))
                    {
                        notGrappled = false;
                        joint.enabled = true;
                        joint.connectedBody = raycastHit.collider.gameObject.GetComponent<Rigidbody2D>();
                        joint.distance = Vector2.Distance(transform.position, raycastHit.collider.gameObject.transform.position);

                        movementScript.enabled = false;

                        rope.enabled = true;
                        rope.SetPosition(1, raycastHit.collider.gameObject.transform.position);

                    }
                }
                else if (Input.GetKeyDown(KeyCode.E) && !notGrappled)
                {
                    Vector2 velocityBefore = rigidbody.velocity;

                    joint.enabled = false;
                    rope.enabled = false;
                    notGrappled = true;
                    rigidbody.velocity = velocityBefore;
                }

            }

            if (notGrappled)
            {
                if (movementScript.isGrounded())
                {
                    movementScript.enabled = true;
                }
            }
        
        }
    }

    private void FixedUpdate()
    {
        if (grappleEnabled)
        {
            if (!notGrappled)
            {
                AddSwingSpeed();
            }
        }
        
    }
    void AddSwingSpeed()
    {
        speed = rigidbody.velocity.x;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(new Vector2(rigidbody.velocity.x - 5, rigidbody.velocity.y).magnitude <= maxSpeed && (rigidbody.velocity.x < 0) && (rigidbody.transform.position.x > raycastHit.point.x))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x - 5, rigidbody.velocity.y);
                //rigidbody.AddForce(new Vector2(-3,0), ForceMode2D.Impulse);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (new Vector2(rigidbody.velocity.x + 5, rigidbody.velocity.y).magnitude <= maxSpeed && (rigidbody.velocity.x > 0) && (rigidbody.transform.position.x < raycastHit.point.x))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x + 5, rigidbody.velocity.y);
                //rigidbody.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
            }
        }
    }


}
