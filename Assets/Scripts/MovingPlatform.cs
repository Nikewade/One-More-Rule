using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float period; //in seconds
    public float spd;
    private int timeTicks = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
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
