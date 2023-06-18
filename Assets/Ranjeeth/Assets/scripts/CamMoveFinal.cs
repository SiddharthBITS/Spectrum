using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveFinal : MonoBehaviour
{
    // Start is called before the first frame update
     GameObject player;
    public Transform[] check;
    public Transform[] pos;
    public Camera camera;
    public int n;
    Vector3 target;
    public float speed = 0.1f;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for(int i = 0 ; i < n ; i++)
        {
            if(player.transform.position.x >= check[i].position.x && player.transform.position.x < check[i+1].position.x )
        {
            target = new Vector3(pos[i].position.x , pos[i].position.y, -10);
            Vector3 smoothPosition = Vector3.Lerp(GetComponent<Camera>().transform.position , target , speed);
           // camera.transform.position = Vector2.MoveTowards(camera.transform.position, target , 100 ) ;
           GetComponent<Camera>().transform.position = smoothPosition;

        }

        }
        
    }
}
