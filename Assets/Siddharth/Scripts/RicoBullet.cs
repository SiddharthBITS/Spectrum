using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicoBullet : MonoBehaviour
{
    public float speed;
    public float damage;
    int rebounds = 0;
    public int reboundLimit = 5;
    public Rigidbody2D rb;
    public TrailRenderer trail;
    public ParticleSystem destroy;
    public Material trailMaterial;
    void Start()
    {
        trail.material = trailMaterial;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        rb.velocity = speed * direction.normalized;
        rebounds = 0;
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * -90);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            rebounds++;
            if(rebounds >= reboundLimit)
            {
                Instantiate(destroy, transform.position, Quaternion.identity);
                destroy.Play();
                Destroy(gameObject);
            }
        }
    }
}
