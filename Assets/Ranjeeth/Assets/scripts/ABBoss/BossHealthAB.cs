using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthAB : MonoBehaviour
{
    int bossColor;
    GameObject player;
    public int bossHP = 1;


    // Start is called before the first frame update
    void Start()
    {
        bossColor = ABBossBehaviour.currentColor;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHP <=0)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //here check with bullet color
        if (collision.gameObject.tag =="Bullet" && player.GetComponent<ComplementaryChecker>().isComplementaryColor(bossColor))
        {
            bossHP --;
            
            

        }
        
    }
}
