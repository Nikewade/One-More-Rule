using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPlatform : MonoBehaviour
{
    public float period; //in seconds
    public float spd;
    public float jumpHeight = 35;
    private int timeTicks = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && (collision.gameObject.transform.position.y > (this.transform.position.y + 1)))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
        }
    }

    void FixedUpdate()
    {

        //updates 50 times per second
        timeTicks = timeTicks + 1;
        if (timeTicks <= (period * 50) / 2)
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, this.transform.GetChild(0).gameObject.transform.position, spd * Time.deltaTime);
        }
        else
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, this.transform.GetChild(0).gameObject.transform.position, -spd * Time.deltaTime);
        }
        if (timeTicks >= (period * 50))
        {
            timeTicks = 0;
        }
    }
}
