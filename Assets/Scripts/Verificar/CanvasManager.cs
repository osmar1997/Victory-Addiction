using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;

    public void ActiveGameOver()
    {
        gameOverText.gameObject.SetActive(true);    
    
    }
}
