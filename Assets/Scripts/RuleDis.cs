using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RuleDis : MonoBehaviour
{
    public GameObject controller;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        switch (controller.GetComponent<InitializeRules>().rule)
        {
            case 0:
                this.GetComponent<TextMeshProUGUI>().text = "Rule: You must collect all candies!";
                break;
            case 1:
                this.GetComponent<TextMeshProUGUI>().text = "Rule: You may not collect candies!";
                break;
            case 2:
                this.GetComponent<TextMeshProUGUI>().text = "Rule: Set fire to yourself as well as enemies, but hurry to put it out!";
                break;
            case 3:
                this.GetComponent<TextMeshProUGUI>().text = "Rule: You must kill all enemies!";
                break;
            case 4:
                this.GetComponent<TextMeshProUGUI>().text = "Rule: You may not jump!";
                break;
            case 5:
                this.GetComponent<TextMeshProUGUI>().text = "Rule: You may not shoot!";
                break;
            case 6:
                this.GetComponent<TextMeshProUGUI>().text = "Rule: You must finish within the time limit!";
                break;
        }
    }
}
