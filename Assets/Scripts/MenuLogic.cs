using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuLogic : MonoBehaviour
{
    public void Exitgame()
    {
        Application.Quit();
    }

    public void Switchtogame()
    {
        SceneManager.LoadScene("Game");
    }
}
