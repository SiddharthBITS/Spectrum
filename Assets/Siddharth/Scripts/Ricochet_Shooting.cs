using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochet_Shooting : MonoBehaviour
{
    public float shootEvery;
    public float timer;
    public float bulletVelocity;
    public GameObject player;
    public GameObject ricoProjectile;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > shootEvery)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y).normalized;
        Vector2 self = new Vector2(transform.position.x, transform.position.y).normalized;
        GameObject bullet = Instantiate(ricoProjectile, transform.position, Quaternion.identity);
        Vector2 dir = self - target;
        bullet.GetComponent<Rigidbody2D>().AddForce(bulletVelocity * dir.normalized);
    }
}
