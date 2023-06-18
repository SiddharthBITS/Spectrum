using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    //public GameObject walkSound;

    [SerializeField] private LayerMask platformLayerMask;
    public float moveSpeed = 5, jumpVelocity = 5, jumpPressedRememberTime = 0.2f, groundedRememberTime = 0.2f, jumpInAirTime = 0.3f, jumpInAir;
    float moveDirection, jumpPressedRemember, groundedRemember;
    bool canHoldJump;
    public bool isInAir;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    BoxCollider2D boxCollider;

    public bool canMove = true;

    public int playerHP = 1;
    bool withinJumpTower = false;
    
    public bool doubleJumpEnabled = false;

    [SerializeField] GameObject currentWall;
    bool isOnAWall = false;
    public float wallJumpVelocity;
    public float wallJumpAngle;
    

    void Start()
    {
        
        rigidBody = GetComponent <Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (canMove)
        {
            moveDirection = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                jumpPressedRemember = jumpPressedRememberTime;
                if (isInAir && doubleJumpEnabled)
                {
                    Debug.Log("I jumped double wala!");
                    rigidBody.velocity = Vector2.up * jumpVelocity;
                    isInAir = false;
                }
            }
            if ((isGrounded() || withinJumpTower)&& !isOnAWall)
            {
                groundedRemember = groundedRememberTime;
                jumpInAir = jumpInAirTime;
                canHoldJump = true;
                isInAir = false;
            }
            if ((jumpPressedRemember > 0) && (groundedRemember > 0))
            {
                rigidBody.velocity = Vector2.up * jumpVelocity;
                jumpPressedRemember = 0;
                groundedRemember = 0;
                isInAir = true;
            }

            if (Input.GetKey(KeyCode.Space) && canHoldJump && doubleJumpEnabled && !isOnAWall)
            {
                if (jumpInAir > 0)
                {
                    rigidBody.velocity = Vector2.up * jumpVelocity;
                    jumpInAir -= Time.deltaTime;
                    isInAir = true;
                }
                else
                {
                    canHoldJump = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space) && doubleJumpEnabled && !isOnAWall)
            {
                canHoldJump = false;
                jumpInAir = 0;
            }

            if (Input.GetKeyUp(KeyCode.Space) && isOnAWall)
            {
                Vector2 normalVector = currentWall.transform.position - gameObject.transform.position;

                Vector2 jumpDir = (Quaternion.Euler(0, 0, -wallJumpAngle) * normalVector).normalized;

                rigidBody.velocity = jumpDir * wallJumpVelocity;
            }

            isGrounded();

            jumpPressedRemember -= Time.deltaTime;
            groundedRemember -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            //Move update
            {
                //walkSound.SetActive(true);
                rigidBody.velocity = new Vector2(moveSpeed * moveDirection, rigidBody.velocity.y);

                if (moveDirection == -1)
                {
                    spriteRenderer.flipX = true;
                }
                else if (moveDirection == 1)
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
        else
        {
            //walkSound.SetActive(false);

        }

    }

    public bool isGrounded()
    {
        Color raycolor;
   
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.05f, platformLayerMask);
        if (raycastHit.collider != null)
        {
            raycolor = Color.green;
        }
        else
        {
            raycolor = Color.red;
        }

        Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + 0.1f), raycolor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + 0.1f), raycolor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y), Vector2.right * (boxCollider.bounds.extents.x) * 2, raycolor);
        return raycastHit.collider != null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "JumpTower")
        {
            withinJumpTower = true;
        }

        if (collision.CompareTag("Wall"))
        {
            currentWall = collision.gameObject;
            isOnAWall = true;
            Debug.Log("Wall encountered");
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "JumpTower")
        {
            withinJumpTower = false;
        }
        if (collision.CompareTag("Wall"))
        {
            currentWall = null;
            isOnAWall = false;
            Debug.Log("Wall left");
        }
    }
}
