using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts : MonoBehaviour
{
    Color trans = new Color();
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SecondDeath");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        trans = this.GetComponent<SpriteRenderer>().color;
        trans.a = trans.a - 0.015f;
        this.GetComponent<SpriteRenderer>().color = trans;
        pos = this.gameObject.transform.position;
        pos.y = pos.y + 0.03f;
        this.gameObject.transform.position = pos;
    }

    IEnumerator SecondDeath()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
