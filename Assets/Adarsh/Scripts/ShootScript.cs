using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed = 1;

    Vector3 destination;
    GameObject projectile;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.z = 0;

            projectile = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        }

        if(projectile != null)
        {
            projectile.transform.position = Vector2.MoveTowards(projectile.transform.position, destination, speed);
        }
        
    }

}
