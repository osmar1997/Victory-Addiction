using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyOpen3 : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public AudioSource DoorOpenSound;
    public bool Action = false;

    void Start()
    {
        Instruction.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (CharacterStats.Instance.currentMoney >= 1000 && CharacterStats.Instance.currentXp >= 8)
            {
                if (Action == true)
                {
                    Debug.Log("33333333333");
                    Instruction.SetActive(false);
                    AnimeObject.GetComponent<Animator>().Play("OpenDoor3");
                    ThisTrigger.SetActive(false);
                    DoorOpenSound.Play();
                    Action = false;
                    CharacterStats.Instance.currentMoney = CharacterStats.Instance.currentMoney - 1000;
                }
                CharacterStats.Instance.currentArena = 3;
            }
        }

    }
}
