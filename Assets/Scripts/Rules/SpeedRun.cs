using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedRun : MonoBehaviour
{
    public float seconds = 300;
    public TextMeshProUGUI text;
    GameObject sceneController;

    void Start()
    {
        sceneController = GameObject.Find("SceneController");
        text = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine("KillPlayer");
    }


    void Update()
    {
        if (seconds > 0)
        {
            seconds -= Time.deltaTime;
        }
        double b = System.Math.Round(seconds, 2);
        text.text = ((int) b).ToString();
    }


    IEnumerator KillPlayer()
    {
        yield return new WaitForSeconds(seconds);
        sceneController.GetComponent<InitializeRules>().Death();
    }
}
