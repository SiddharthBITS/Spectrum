using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWheelDetectScript : MonoBehaviour
{
    ComplementaryChecker script;
    public int color;

    void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<ComplementaryChecker>();
    }
  
    void Update()
    {
       if (script.isSameColor(color))
       {
          this.GetComponent<PolygonCollider2D>().enabled = false;
       }
       else
       {
          this.GetComponent<PolygonCollider2D>().enabled = true;
       }
    }

}
