using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoJump : MonoBehaviour
{
    CharacterController controller;
    InitializeRules rules;

    private void Start()
    {
        controller = GetComponentInParent<CharacterController>();
        rules = GameObject.Find("SceneController").GetComponent<InitializeRules>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isJumping)
        {
            controller.isJumping = false;
            rules.Death();
        }
    }

}
