using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardWallScript : MonoBehaviour
{
    public int wallColor;
    ComplementaryChecker script;
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<ComplementaryChecker>();
    }

    void Update()
    {
        if (script.isComplementaryColor(wallColor))
        {
            this.tag = "Destroyable";
        }
        else
        {
            this.tag = "Untagged";
        }

    }
}