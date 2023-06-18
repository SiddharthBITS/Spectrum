using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovefinalY : MonoBehaviour
{
    // Start is called before the first frame update
     GameObject player;
    public Transform[] check;
    public Transform[] pos;
    public Camera camera;
    public int n;
    Vector3 target;
    public float speed = 0.1f;
    public Transform initialPos;
    public Transform Pos1;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for(int i = 0 ; i < n ; i++)
        {
            if(player.transform.position.y >= check[i].position.y && player.transform.position.y < check[i+1].position.y )
        {
            target = new Vector3(pos[i].position.x , pos[i].position.y, -10);
            Vector3 smoothPosition = Vector3.Lerp(GetComponent<Camera>().transform.position , target , speed);
           // camera.transform.position = Vector2.MoveTowards(camera.transform.position, target , 100 ) ;
           GetComponent<Camera>().transform.position = smoothPosition;

        }
        if(player.transform.position.y <= check[i].position.y && player.transform.position.y > check[i-1].position.y )
        {
            target = new Vector3(pos[i-1].position.x , pos[i-1].position.y, -10);
            Vector3 smoothPosition = Vector3.Lerp(GetComponent<Camera>().transform.position , target , speed);
           // camera.transform.position = Vector2.MoveTowards(camera.transform.position, target , 100 ) ;
           GetComponent<Camera>().transform.position = smoothPosition;

        }

        }
        if(player.transform.position.y < check[0].position.y  )
        {
            Vector3 smoothPosition = Vector3.Lerp(GetComponent<Camera>().transform.position , initialPos.position  , speed);
            this.transform.position = smoothPosition;


        }
        
    }
}
