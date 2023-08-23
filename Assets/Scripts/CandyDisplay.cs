using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandyDisplay : MonoBehaviour
{
    public GameObject controller;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = "Candies uneaten:  " + controller.GetComponent<CollectiblesTotal>().candy;
    }
}
