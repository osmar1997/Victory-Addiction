using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botaoPausa;
    [SerializeField] private GameObject menuPausa;

    public void Pausa()
    {
        Time.timeScale = 0f;
        botaoPausa.SetActive(false);
        menuPausa.gameObject.SetActive(true); 
    }

    public void Retomar()
    {
        Time.timeScale = 1f;
        botaoPausa.SetActive(true);
        menuPausa.gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
