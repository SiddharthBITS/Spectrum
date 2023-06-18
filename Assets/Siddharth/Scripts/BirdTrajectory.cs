using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTrajectory : MonoBehaviour
{
        /* public Color32 black  = new Color32(0,   0,   0,   255);
    public Color32 red    = new Color32(255, 0,   0,   255);
    public Color32 orange = new Color32(255, 69,  0,   255);
    public Color32 yellow = new Color32(255, 255, 0,   255);
    public Color32 green  = new Color32(0,   255, 0,   255);
    public Color32 blue   = new Color32(0,   0,   255, 255);
    public Color32 purple = new Color32(128, 0,   128, 255);
    Color32[] colors = new Color32[7];
    SpriteRenderer sr;
    public int color;
    public GameObject player;*/
   // int playerColor;
    private Vector3 ballPos;
    float distance;
    Vector2 direction;
    private Vector2 forceApplied;
    public GameObject bird;
    public Transform anchor;
    public int dotNumber;
    public GameObject dotsParent;
    public GameObject dotsPrefab;
    public float dotSpacing;
    Transform[] dotsList;
    Vector2 pos;
    float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        Hide();
        PrepareDots();
       /*  colors[0] = black;
        colors[1] = red;
        colors[2] = orange;
        colors[3] = yellow;
        colors[4] = green;
        colors[5] = blue;
        colors[6] = purple;
        sr = dotsPrefab.GetComponent<SpriteRenderer>();*/

        
    }
    void PrepareDots()
    {
        dotsList = new Transform[dotNumber];
        for( int i = 0 ; i < dotNumber ; i++)
        {
            dotsList [i] = Instantiate (dotsPrefab, null).transform;
            dotsList [i].parent = dotsParent.transform;
        }

    }
    public void Show()
    {
        dotsParent.SetActive(true);
    }
    public void Hide()
    {
        dotsParent.SetActive(false);
    }
   public void UpdateDots ()
	{
        ballPos = bird.transform.position;
        forceApplied = new Vector2 (1*(1.5f*1.5f) *distance * direction.x *1.6f, 1*(1.5f*1.5f) *  distance * direction.y*1.6f);
        

		timeStamp = dotSpacing;
		for (int i = 0; i < dotNumber; i++) {
			pos.x = (ballPos.x + forceApplied.x * timeStamp);
			pos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp)/2f;
		
			                  
			
			dotsList [i].position = pos;
			timeStamp += dotSpacing;
		}
	}

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(bird.transform.position , anchor.position)    ;  
        direction = new Vector2((anchor.position.x - bird.transform.position.x)/distance ,(anchor.position.y - bird.transform.position.y)/distance   ) ;
       // color = player.GetComponent<ColourManager>().currentColor;
       // sr.color = colors[color];
    }
}
