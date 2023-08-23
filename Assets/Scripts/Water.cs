using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Fireball fireball;

    private void Start()
    {
        fireball = GameObject.Find("Fireball").GetComponent<Fireball>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        fireball.onFire = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        fireball.onFire = false;
    }

}
