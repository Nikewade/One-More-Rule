using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("SceneController");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            controller.gameObject.GetComponent<InitializeRules>().Death();
        }
    }
}
