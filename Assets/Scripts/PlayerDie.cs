using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerDie : MonoBehaviour
{
    public Sprite deathSprite;
    public GameObject cameraTracking;
    GameObject rules;
    AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        source = GameObject.Find("Player").GetComponent<AudioSource>();
        cameraTracking = GameObject.Find("CM vcam1");
        rules = GameObject.Find("Rules");
    }

    public void Die()
    {
        this.GetComponent<CharacterController>().enabled = false;
        rules.SetActive(false);
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<Footsteps>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = deathSprite;
        this.GetComponent<CapsuleCollider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-15,15), 20);
        cameraTracking.GetComponent<CinemachineVirtualCamera>().Follow = null;

        source.PlayOneShot(clip);
    }
}
