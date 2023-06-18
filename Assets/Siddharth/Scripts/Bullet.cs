using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float range;
    public float damage;
    public Rigidbody2D rb;
    public TrailRenderer trail;
    public ParticleSystem destroy;
    GameObject[] player;
    public Material[] trailMaterials;
    Vector2 startPos;
    void Start()
    {
        damage /= 2;
        player = GameObject.FindGameObjectsWithTag("Player");
        trail.material = trailMaterials[player[0].GetComponent<ColourManager>().currentColor];
        startPos = transform.position;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        rb.velocity = speed * direction.normalized;
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, startPos) > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall") || collision.CompareTag("Ground"))
        {
            Instantiate(destroy, transform.position, Quaternion.identity);
            destroy.Play();
            Destroy(gameObject);
        }
        if(collision.CompareTag("enemy"))
        {
            if (collision.attachedRigidbody.gameObject.GetComponent<AIpatrolShoot>().projectileColor == (player[0].GetComponent<ColourManager>().currentColor + 3) % 6)
            {
                collision.attachedRigidbody.gameObject.GetComponent<EnemyHealth>().health -= damage;
                Instantiate(destroy, transform.position, Quaternion.identity);
                destroy.Play();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
