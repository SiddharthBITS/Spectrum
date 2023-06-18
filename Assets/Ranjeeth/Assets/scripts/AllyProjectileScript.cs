using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyProjectileScript : MonoBehaviour
{
    float enemyHP = BossBehaviour.BossHP;
    public int projectileColor;
    

    void Start()
    {
    }
       

     void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Boss" && enemyHP == 1&&  GameObject.FindGameObjectWithTag("Boss").GetComponent<ComplementaryChecker2>().isComplementaryColor(projectileColor))
        {
            //GameObject.Destroy(collision.gameObject); 
            BossBehaviour.BossHP --;

        }
        else if (collision.gameObject.tag == "Boss" && enemyHP > 1 &&  GameObject.FindGameObjectWithTag("Boss").GetComponent<ComplementaryChecker2>().isComplementaryColor(projectileColor))
        {
            BossBehaviour.BossHP --;
        }

    }
}
