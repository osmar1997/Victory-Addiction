using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Cena Principal");
        Time.timeScale = 1f;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Menu Scene");
        Time.timeScale = 1f;
    }
}

