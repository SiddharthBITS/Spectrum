using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealh;
    public float health;
    public GameObject canvas;
    public Image healthbar;

    private void Start()
    {
        health = maxHealh;
    }

    void Update()
    {
        if(health < maxHealh)
        {
            canvas.SetActive(true);
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        healthbar.fillAmount = (health / maxHealh);
    }
}
