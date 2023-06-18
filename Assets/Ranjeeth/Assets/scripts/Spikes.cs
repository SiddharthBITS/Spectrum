using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Animator animation;
    // Start is called before the first frame update
    void Awake()
    {
        animation = GetComponent<Animator>();
         animation.SetBool("Spike",false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animation.SetBool("Spike",true);
        }
        if(Input.GetMouseButtonDown(1))
        {
            animation.SetBool("Spike",false);
        }
       
        
    }
}
