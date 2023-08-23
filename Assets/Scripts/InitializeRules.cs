using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeRules : MonoBehaviour
{
    public int rulesNum;
    public int rule;
    public GameObject deathScreen;
    public GameObject player;
    public List<GameObject> rules;
    // Start is called before the first frame update
    void Start()
    {
        //pick a rule
        rule = Random.Range(0, (rules.Count));
        Debug.Log(rules[rule].name);
        rules[rule].SetActive(true);
    }

    private void Update()
    {
        //just go to menu when you hit escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Death()
    {
        player.GetComponent<PlayerDie>().Die();
        StartCoroutine("DeathScreen");
    }

    IEnumerator DeathScreen()
    {
        yield return new WaitForSeconds(1.5f);
        deathScreen.SetActive(true);
    }
}
