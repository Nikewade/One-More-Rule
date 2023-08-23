using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDeath : MonoBehaviour
{
    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("SceneController");
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            controller.gameObject.GetComponent<InitializeRules>().Death();
        }
    }
}
