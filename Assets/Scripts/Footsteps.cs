using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public AudioSource audioSource;
    public Rigidbody2D controller;
    public float footstepThreshsold;
    public float footstepRate;

    
    private float lastFootstepTime;

    CharacterController cc;


    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    private void Update()
    {
        if (controller.velocity.magnitude > 7 && cc.isGrounded)
        {
            if (Time.time - lastFootstepTime > footstepRate)
            {
                lastFootstepTime = Time.time;
                audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
            }
        }
    }
}
