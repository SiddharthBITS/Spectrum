using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{
    public Transform spawnPosition;
    public float stopDistance = 1, speed = 5;
    GameObject player;

    public Transform check1;
    public Transform check2;
    public Transform check3;
    public Transform check4;
    public Transform check5;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;

    public bool hasReached = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (player && !hasReached)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            if (!hasReached)
            {
                if (transform.position.x < check1.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);
                    if (transform.position == pos1.position)
                    {
                        hasReached = true;
                    }
                }
                else if (transform.position.x >= check1.position.x && transform.position.x <= check2.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, pos2.position, speed * Time.deltaTime);
                    if (transform.position == pos2.position)
                    {
                        hasReached = true;
                    }
                }
                else if (transform.position.x >= check2.position.x && transform.position.x <= check3.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, pos3.position, speed * Time.deltaTime);
                    if (transform.position == pos3.position)
                    {
                        hasReached = true;
                    }
                }
                else if (transform.position.x >= check3.position.x && transform.position.x <= check4.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, pos4.position, speed * Time.deltaTime);
                    if (transform.position == pos4.position)
                    {
                        hasReached = true;
                    }
                }
                else if (transform.position.x >= check4.position.x && transform.position.x <= check5.position.x)
                {
                    //transform.position = Vector2.MoveTowards(transform.position, pos4.position, speed * Time.deltaTime);
                    /*if (transform.position == pos1.position)
                    {
                        hasReached = true;
                    }*/
                }
            }
            
        }

    }

}
