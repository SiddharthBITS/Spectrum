using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlingShot : MonoBehaviour
{
    public GameObject bird;
    public BirdTrajectory trajectory;
    public TextMeshProUGUI ballCount;
    public GameObject canvas;
    public GameObject canvasQ;
    public GameObject canvasCount;
    public GameObject player;
    public GameObject birdNest;
    public bool aBirdOnShot = false;
    bool inside = false;
    [SerializeField] bool slingShotActive = false;
    public int balls = 5;

    Vector2 birdPos;
    void Start()
    {
        //trajectory = this.GetComponent<BirdTrajectory>();
        birdPos = bird.transform.position;
    }
    private void Update()
    {
        trajectory.UpdateDots();
        //trajectory.Show();
         

        if(balls == 0)
        {
            StartCoroutine("CloseSlingshot");
        }
        if (inside && !slingShotActive && Input.GetKeyDown(KeyCode.E) && balls >= 0)
        {
            activteSlingshot();
           // trajectory.Show();
        }
        
        if((inside && slingShotActive && Input.GetKeyDown(KeyCode.Q) && aBirdOnShot) || balls == -1)
        {
            deactivteSlingshot();
           // trajectory.Hide();
        }
        if(aBirdOnShot)
        {
            canvasQ.SetActive(true);
           // trajectory.Show();
        }
        else
        {
            canvasQ.SetActive(false);
            //trajectory.Hide();
        }
        if(slingShotActive)
        {
            canvasCount.SetActive(true);
            ballCount.text = balls.ToString();
           // trajectory.Show();
            


        }
        else
        {
            canvasCount.SetActive(false);
            //trajectory.Hide();
        }
    }

    IEnumerator CloseSlingshot()
    {
        yield return new WaitForSeconds(bird.GetComponent<Bird>().destroyTime);
        deactivteSlingshot();
        canvas.SetActive(false);
        canvasQ.SetActive(false);
        canvasCount.SetActive(false);
    }

    void activteSlingshot()
    {
        slingShotActive = true;
        SpawnBird();
        canvas.SetActive(false);
        // Stop player movement
        player.GetComponent<ControllerScript>().canMove = false;
        
       
    }

    void deactivteSlingshot()
    {
        aBirdOnShot = false;
        slingShotActive = false;
        canvas.SetActive(true);
        bird.SetActive(false);
        // Resume player movement
        player.GetComponent<ControllerScript>().canMove = true;
       // trajectory.Hide();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && balls > 0)
        {
            inside = true;
            if (!canvas.activeSelf)
            {
                canvas.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inside = false;
            if (canvas.activeSelf)
            {
                canvas.SetActive(false);
            }
        }
    }

    void SpawnBird()
    {
        aBirdOnShot = true;
        bird.SetActive(true);
        bird.transform.position = birdPos;
    }
}
