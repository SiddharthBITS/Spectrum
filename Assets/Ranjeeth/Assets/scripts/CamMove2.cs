using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove2 : MonoBehaviour
{
    public GameObject player;
    public Transform check1;
    public Transform check2;
    /*public Transform check3;
    public Transform check4;
    public Transform check5;*/
    public Transform pos1;
    /*public Transform pos2;
    public Transform pos3;
    public Transform pos4;*/
    public Camera camera;
    Vector3 target;
    public float speed = 0.125f;
    CameraFollowScript script1;
    // Start is called before the first frame update
    void Start()
    {
        script1 = camera.GetComponent<CameraFollowScript>();
        script1.enabled = false;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player.transform.position.x <= check1.position.x && player.transform.position.x >= check2.position.x   )
        {
            target = new Vector3(pos1.position.x , pos1.position.y, -10);
            Vector3 smoothPosition = Vector3.Lerp(camera.transform.position , target , speed);
           // camera.transform.position = Vector2.MoveTowards(camera.transform.position, target , 100 ) ;
           camera.transform.position = smoothPosition;


        }
        /*else if(player.transform.position.x >= check2.position.x && player.transform.position.x <= check3.position.x )
        {
            target = new Vector3(pos2.position.x , pos2.position.y, -10);
            Vector3 smoothPosition = Vector3.Lerp(camera.transform.position , target , speed);
            camera.transform.position = smoothPosition;



        }
        else if(player.transform.position.x >= check3.position.x && player.transform.position.x <= check4.position.x  )
        {
             target = new Vector3(pos3.position.x , pos3.position.y, -10);
            Vector3 smoothPosition = Vector3.Lerp(camera.transform.position , target , speed);
            camera.transform.position = smoothPosition;

        }
        else if(player.transform.position.x >= check4.position.x && player.transform.position.x <= check5.position.x)
        {
             target = new Vector3(pos4.position.x , pos3.position.y, -10);
            Vector3 smoothPosition = Vector3.Lerp(camera.transform.position , target , speed);
            camera.transform.position = smoothPosition;


        }*/
        else if(player.transform.position.x <= check2.position.x)
        {
            script1.enabled  = true;


        }

        
    }
}
