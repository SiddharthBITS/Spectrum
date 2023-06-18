using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWallScript : MonoBehaviour
{
    public int wallColor;
    ComplementaryChecker script;
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<ComplementaryChecker>();
    }

    void Update()
    {
        if(script.isSameColor(wallColor))
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }

    }
}
