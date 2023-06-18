using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject light;
    public GameObject player;
    public Transform Cam;
    public Transform c3; 


    // Start is called before the first frame update
    void Start()
    {
        light.GetComponent<LightTurn>().speed = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > c3.position.x)
        {
            light.GetComponent<LightTurn>().speed = 5;

        }
        else
        {
            light.GetComponent<LightTurn>().speed = 0;

        }
        
    }
}
