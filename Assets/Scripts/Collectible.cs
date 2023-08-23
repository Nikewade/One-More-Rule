using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public float moveDistance;
    public int score = 1;
    AudioSource source;
    public AudioClip clip;

    private Vector3 startPos;
    private bool movingToStart;
    GameObject gamemanager;
    CollectiblesTotal collectibles;


    private void Start()
    {
        source = GameObject.Find("Player").GetComponent<AudioSource>();
        startPos = transform.position;
        gamemanager = GameObject.Find("SceneController");
        collectibles = gamemanager.GetComponent<CollectiblesTotal>();
    }

    void Update()
    {

        //bounce
        if (movingToStart)
        {
            //Dont want it to move at a speed based on frames so delta time is between frames
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            if (transform.position == startPos)
            {
                movingToStart = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos + (moveDirection * moveDistance), speed * Time.deltaTime);
            if (transform.position == startPos + (moveDirection * moveDistance))
            {
                movingToStart = true;
            }
        }

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Candy"))
            {
                collectibles.candy -= score;
            }

            if (gameObject.CompareTag("Pumpkin"))
            {
                collectibles.pumpkin -= score;
            }

            source.PlayOneShot(clip);
            Destroy(gameObject);
        }


    }
}
