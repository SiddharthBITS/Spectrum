using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplementaryChecker : MonoBehaviour
{
    public bool isComplementaryColor(int checkColor)
    {
        if (((this.GetComponent<ColourManager>().currentColor + 3) % 6) == checkColor)
        {
            return true;
        }
        else return false;
    }

    public bool isSameColor(int checkColor)
    {
        if (this.GetComponent<ColourManager>().currentColor == checkColor)
        {
            return true;
        }
        else return false;
    }
}
