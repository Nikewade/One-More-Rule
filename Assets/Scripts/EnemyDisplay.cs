using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDisplay : MonoBehaviour
{
    public GameObject controller;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = "Enemies left:  " + controller.GetComponent<CollectiblesTotal>().enemy;
    }
}
