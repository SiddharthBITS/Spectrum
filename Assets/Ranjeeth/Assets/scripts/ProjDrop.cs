using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPos;
    public float spawnRate;
    public GameObject projectile;
    float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnRate)
        {
            timer -= spawnRate;
            Instantiate(projectile , new Vector2(startPos.position.x , startPos.position.y) ,  Quaternion.identity);
        }


        
    }
}
