using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float period; //in seconds
    public float spd;
    private int timeTicks = 0;
    public int health = 2;
    public Color hitColor;
    public AudioClip hitAudio;
    AudioSource source;
    int hitCounter = 0;
    Quaternion normal = Quaternion.Euler(0, 0, 0);
    Quaternion flipped = Quaternion.Euler(0, 180, 0);
    CollectiblesTotal total;
    int dirTrack = 0;

    private void Start()
    {
        source = GameObject.Find("Player").GetComponent<AudioSource>();
        total = GameObject.Find("SceneController").GetComponent<CollectiblesTotal>();
        if (this.gameObject.transform.position.x <= this.transform.GetChild(0).gameObject.transform.position.x)
        {
            dirTrack = 0;
        }
        else
        {
            dirTrack = 1;
            spd = -spd;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitCounter++;
            source.PlayOneShot(hitAudio);
            StartCoroutine("HitColor");
        }else if(collision.gameObject.CompareTag("Bullet_Fireball"))
        {
            hitCounter += 20;
            source.PlayOneShot(hitAudio);
            StartCoroutine("HitColor");
        }
    }



    void FixedUpdate()
    { 
        if (hitCounter >= health)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.transform.SetParent(null);
            Destroy(this.gameObject);
            total.enemy -= 1;
        }

        //updates 50 times per second
        timeTicks = timeTicks + 1;
        if (timeTicks <= (period * 50) / 2)
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, this.transform.GetChild(0).gameObject.transform.position, -spd * Time.deltaTime);
            if (dirTrack == 0)
            {
                this.gameObject.transform.rotation = flipped;
            }
            else
            {
                this.gameObject.transform.rotation = normal;
            }
        }
        else
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, this.transform.GetChild(0).gameObject.transform.position, -spd * Time.deltaTime);
            if (dirTrack == 1)
            {
                this.gameObject.transform.rotation = flipped;
            }
            else
            {
                this.gameObject.transform.rotation = normal;
            }
        }
        if (timeTicks >= (period * 50))
        {
            timeTicks = 0;
        }
    }

    IEnumerator HitColor()
    {
        transform.GetComponent<SpriteRenderer>().color = hitColor;
        yield return new WaitForSeconds(0.2f);
        transform.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
