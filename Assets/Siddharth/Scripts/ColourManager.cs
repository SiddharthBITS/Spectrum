using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    public GameObject gun;
    public GameObject gunScriptObject;

    public int currentColor = 0;

    public Color32 black  = new Color32(0,   0,   0,   255);
    public Color32 red    = new Color32(255, 0,   0,   255);
    public Color32 orange = new Color32(255, 69,  0,   255);
    public Color32 yellow = new Color32(255, 255, 0,   255);
    public Color32 green  = new Color32(0,   255, 0,   255);
    public Color32 blue   = new Color32(0,   0,   255, 255);
    public Color32 purple = new Color32(255, 0,   221, 255);

    Color32[] colors = new Color32[7];

    void Start()
    {
        colors[0] = black;
        colors[1] = red;
        colors[2] = orange;
        colors[3] = yellow;
        colors[4] = green;
        colors[5] = blue;
        colors[6] = purple;
    }

    void Update()
    {
        // Code to change the color of player and his gun, will have to be change acc to what sprites are chosen
        if (currentColor >= 0 && currentColor <= 7)
        {
            gameObject.GetComponent<SpriteRenderer>().color = colors[currentColor];
        }

        // Everything that uses colors reffers to this script
    }
}
