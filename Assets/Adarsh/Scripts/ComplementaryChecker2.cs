using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplementaryChecker2 : MonoBehaviour
{
    public bool isComplementaryColor(int checkColor)
    {
        if (((BossBehaviour.currentColor + 3) % 6) == checkColor)
        {
            return true;
        }
        else return false;
    }

    public bool isSameColor(int checkColor)
    {
        if (BossBehaviour.currentColor == checkColor)
        {
            return true;
        }
        else return false;
    }
}
