using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationsManager : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;

    void Start()
    {
        MouseSensitive.MouseON += ShowInformations;
        MouseSensitive.MouseOFF += ResetInformations;
    }
    private void OnDestroy()
    {
        MouseSensitive.MouseON -= ShowInformations;
        MouseSensitive.MouseOFF -= ResetInformations;
    }
    private void ShowInformations(string name, string description)
    {
        nameText.text = name;
        descriptionText.text = description;
    }
    private void ResetInformations()
    {
        nameText.text = string.Empty;
        descriptionText.text = string.Empty;
    }
  
}
