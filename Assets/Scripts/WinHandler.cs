using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WinHandler : MonoBehaviour
{
    public Sprite winSprite;
    public GameObject rules;
    public GameObject controller;
    public GameObject player;
    public GameObject cameraTracking;
    public GameObject winScreen;
    public GameObject winning;
    public GameObject fadeIn;
    Color trans = new Color();
    Vector2 pos;
    private bool isWon = false;

    private void Start()
    {
        rules = GameObject.Find("Rules");
        controller = GameObject.Find("SceneController");
        player = GameObject.Find("Player");
        cameraTracking = GameObject.Find("CM vcam1");
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (rules.GetComponent<RuleController>().canWin)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<SpriteRenderer>().sprite = winSprite;
            player.GetComponent<CapsuleCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            cameraTracking.GetComponent<CinemachineVirtualCamera>().Follow = null;
            isWon = true;
            winning.SetActive(true);
            StartCoroutine("WinScreen");
        }
        else
        {
            controller.GetComponent<InitializeRules>().Death();
        }
    }

    private void FixedUpdate()
    {
        if (isWon)
        {
            trans = fadeIn.GetComponent<UnityEngine.UI.Image>().color;
            trans.a = trans.a + 0.011f;
            fadeIn.GetComponent<UnityEngine.UI.Image>().color = trans;
            pos = player.gameObject.transform.position;
            pos.y = pos.y + 0.05f;
            player.gameObject.transform.position = pos;
        }
    }

    IEnumerator WinScreen()
    {
        yield return new WaitForSeconds(2.5f);
        winScreen.SetActive(true);
    }
}
