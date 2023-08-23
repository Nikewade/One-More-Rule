using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoShoot : MonoBehaviour
{
    GameObject sceneController;

    private void Start()
    {
        sceneController = GameObject.Find("SceneController");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)  || Input.GetKey(KeyCode.RightShift))
        {
            sceneController.GetComponent<InitializeRules>().Death();
        }
    }
}
