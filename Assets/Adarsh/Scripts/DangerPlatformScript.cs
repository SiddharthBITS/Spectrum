using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerPlatformScript : MonoBehaviour
{
    GameObject player;
    public int platformColor;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
        if(player.GetComponent<ControllerScript>().isGrounded() && player.GetComponent<ComplementaryChecker>().isComplementaryColor(platformColor))
        {
            GameObject.Destroy(player);
        }
    }
}
