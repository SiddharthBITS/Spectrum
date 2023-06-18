using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingPlatformScript : MonoBehaviour
{
    public Color32 black = new Color32(0, 0, 0, 255);
    public Color32 red = new Color32(255, 0, 0, 255);
    public Color32 orange = new Color32(255, 69, 0, 255);
    public Color32 yellow = new Color32(255, 255, 0, 255);
    public Color32 green = new Color32(0, 255, 0, 255);
    public Color32 blue = new Color32(0, 0, 255, 255);
    public Color32 purple = new Color32(128, 0, 128, 255);

    public float timer = 0, resetTimer = 5.0f;
    bool isRed = true;
    void Update()
    {
        if(timer <= 0)
        {
            if(isRed)
            {
                this.GetComponent<SpriteRenderer>().color = green;
                timer = resetTimer;
                isRed = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = red;
                timer = resetTimer;
                isRed = true;
            }
        }

        timer -= Time.deltaTime;
    }
}
