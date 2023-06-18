using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
   
   
    [SerializeField]

    //private Transform route;



    private int routeToGo;



    private float tParam;



    private Vector2 objectPosition;



    public float speedModifier;

    
   


    private bool coroutineAllowed;
    private Transform[] route = new Transform[1];
    
    


    // Start is called before the first frame update

    void Start()

    {
      
        route[0] =  GameObject.Find("route").transform;
        routeToGo = 0;

        tParam = 0f;

        speedModifier = 2f;

        coroutineAllowed = true;

    }



    // Update is called once per frame

    void Update()

    {
      

        if (coroutineAllowed)

        {

            StartCoroutine(GoByTheRoute(routeToGo));

        }

    }



    private IEnumerator GoByTheRoute(int routeNum)

    {

        coroutineAllowed = false;



        Vector2 p0 = route[0].GetChild(0).position;

        Vector2 p1 = route[0].GetChild(1).position;

        Vector2 p2 = route[0].GetChild(2).position;

        Vector2 p3 = route[0].GetChild(3).position;



        while(tParam < 1)

        {

            tParam += Time.deltaTime * speedModifier;



            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;



            transform.position = objectPosition;

            yield return new WaitForEndOfFrame();

        }



        tParam = 0f;



        routeToGo += 1;



        //if(routeToGo > routes.Length - 1)

        //{

            //routeToGo = 0;
//
        //}



        coroutineAllowed = false;



    }
}
