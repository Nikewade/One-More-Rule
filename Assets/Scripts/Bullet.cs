using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float deleteTime = 1.5f;

    private void Start()
    {
        StartCoroutine("DestroyBullet");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Candy") || collision.transform.CompareTag("Pumpkin"))
            return;
        Destroy(gameObject);
    }


    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(gameObject);
    }
}
