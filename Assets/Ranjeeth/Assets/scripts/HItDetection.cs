using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HItDetection : MonoBehaviour
{
   public GameObject player;
   public GameObject turret;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit Detected");

    }
}
