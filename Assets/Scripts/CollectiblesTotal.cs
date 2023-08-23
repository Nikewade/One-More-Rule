using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesTotal : MonoBehaviour
{
    List<GameObject> candies = new List<GameObject>();
    List<GameObject> enemies = new List<GameObject>();
    List<GameObject> pumpkins = new List<GameObject>();
    public int candy = 0;
    public int pumpkin = 0;
    public int enemy = 0;

    private void Start()
    {
        foreach(GameObject x in GameObject.FindGameObjectsWithTag("Candy"))
        {
            candies.Add(x);
        }
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(x);
        }
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("Pumpkin"))
        {
           pumpkins.Add(x);
        }
        candy = candies.Count;
        enemy = enemies.Count;
        pumpkin = pumpkins.Count;
    }
}
