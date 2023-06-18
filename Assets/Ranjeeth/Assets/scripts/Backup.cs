using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backup : MonoBehaviour
{
    public GameObject player;
    public int pointColor;

    DistanceJoint2D joint;
    ControllerScript movementScript;
    new Rigidbody2D rigidbody;
    LineRenderer rope;
    public float distance = 10.0f;
    [SerializeField] LayerMask grappleLayerMask;
    bool notGrappled = true;
    public float speed;
    RaycastHit2D raycastHit;
    ComplementaryChecker script;

    private void Start()
    {
        script = player.GetComponent<ComplementaryChecker>();
        joint = GetComponent<DistanceJoint2D>();
        movementScript = GetComponent<ControllerScript>();
        rigidbody = GetComponent<Rigidbody2D>();
        rope = GetComponent<LineRenderer>();
        joint.enabled = false;
        rope.enabled = false;
    }
    //&& script.isSameColor(pointColor)

    private void Update()
    {
        rope.SetPosition(0, transform.position);

        if (Input.GetMouseButtonDown(1) && notGrappled && script.isSameColor(pointColor))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            raycastHit = Physics2D.Raycast(transform.position, mousePos - transform.position, distance, grappleLayerMask);
            Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);

            if (raycastHit.collider != null && raycastHit.collider.gameObject.GetComponent<Rigidbody2D>() != null && (Vector2.Distance(transform.position, raycastHit.point)) > 5)
            {
                notGrappled = false;
                joint.enabled = true;
                joint.connectedBody = raycastHit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, raycastHit.point);

                movementScript.enabled = false;

                rope.enabled = true;
                rope.SetPosition(1, raycastHit.point);

            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Vector2 velocityBefore = rigidbody.velocity;

            joint.enabled = false;
            rope.enabled = false;
            notGrappled = true;
            rigidbody.velocity = velocityBefore;
        }
        if (notGrappled)
        {
            if (movementScript.isGrounded())
            {
                movementScript.enabled = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!notGrappled)
        {
            AddSwingSpeed();
        }
    }
    void AddSwingSpeed()
    {
        speed = rigidbody.velocity.x;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(new Vector2(rigidbody.velocity.x - 5, rigidbody.velocity.y).magnitude <= 10 && (rigidbody.velocity.x < 0) && (rigidbody.transform.position.x > raycastHit.point.x))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x - 5, rigidbody.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (new Vector2(rigidbody.velocity.x + 5, rigidbody.velocity.y).magnitude <= 10 && (rigidbody.velocity.x > 0) && (rigidbody.transform.position.x < raycastHit.point.x))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x + 5, rigidbody.velocity.y);
            }
        }
    }


}
