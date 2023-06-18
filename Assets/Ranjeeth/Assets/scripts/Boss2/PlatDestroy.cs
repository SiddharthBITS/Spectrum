using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatDestroy : MonoBehaviour
{
    GameObject player;
    GameObject Checkpoint;
    //public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        Checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Destructable" ||  col.gameObject.tag == "enemy")
        {
            Destroy(col.gameObject);
        }
        else if( col.gameObject.tag == "Player")
        {
            player = col.gameObject;
             player.GetComponent<ControllerScript>().playerHP--;
             player.transform.position = Checkpoint.transform.position;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
     void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Destructable"  || coll.gameObject.tag == "enemy")
        {
            Destroy(coll.gameObject);
        }
        else if( coll.gameObject.tag == "Player")
        {
            player = coll.gameObject;
             player.GetComponent<ControllerScript>().playerHP--;
             player.transform.position = Checkpoint.transform.position;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
