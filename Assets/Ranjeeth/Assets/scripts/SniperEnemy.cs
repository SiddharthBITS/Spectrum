using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SniperEnemy : MonoBehaviour
{
    public LayerMask abc ;
    GameObject Checkpoint;
    int groundColor;
    // Start is called before the first frame update
    public Color32 black  = new Color32(0,   0,   0,   255);
    public Color32 red    = new Color32(255, 0,   0,   255);
    public Color32 orange = new Color32(255, 69,  0,   255);
    public Color32 yellow = new Color32(255, 255, 0,   255);
    public Color32 green  = new Color32(0,   255, 0,   255);
    public Color32 blue   = new Color32(0,   0,   255, 255);
    public Color32 purple = new Color32(128, 0,   128, 255);
    Color32[] colors = new Color32[7];
    LineRenderer lr ;
    SpriteRenderer sr;
    public float lazerDistance = 900f;
     GameObject player;
    Vector2 a;
    Vector2 b;
    Vector2 dir;
    public int enemyColor;
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");
         Checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
        colors[0] = purple;
        colors[1] = red;
        colors[2] = orange;
        colors[3] = yellow;
        colors[4] = green;
        colors[5] = blue;
        colors[6] = black;
        lr = this.GetComponent<LineRenderer>();
        sr = this.GetComponent<SpriteRenderer>();
        lr.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = colors[enemyColor];
        a = new Vector2(player.transform.position.x , player.transform.position.y);
        b = new Vector2(transform.position.x , transform.position.y);
        dir = (a-b)/Vector2.Distance(a,b);
        

        if(player.GetComponent<ComplementaryChecker>().isComplementaryColor(enemyColor))
        {
            if(Vector2.Distance(a , b) <= lazerDistance)
        {
            lr.enabled = true;
            lr.SetPosition(0, b);
            lr.SetPosition(1, a);
            lr.SetColors(colors[enemyColor], colors[enemyColor]);
            RaycastHit2D hit = Physics2D.Raycast(transform.position , dir , lazerDistance , abc);
            if(hit.collider.tag == "Player")
            {
                //Destroy(player);
                player.GetComponent<ControllerScript>().playerHP--;
             player.transform.position = Checkpoint.transform.position;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            

        }
         if(Vector2.Distance(a , b) > lazerDistance)
        {
            lr.enabled = false;
        }


        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Bullet" && player.GetComponent<ComplementaryChecker>().isComplementaryColor(enemyColor))
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Ground")
        {
            groundColor = collision.gameObject.GetComponent<EnemyProjectileScript>().projectileColor;
            if((enemyColor + 3)%6 == groundColor)
            {
                Destroy(gameObject);
            }

        }
        
    }
}
