using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyDoorOpen2 : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (CharacterStats.Instance.currentMoney >= 500 && CharacterStats.Instance.currentXp >= 2)
            {
                if (Action == true)
                {
                    Instruction.SetActive(false);
                    AnimeObject.GetComponent<Animator>().Play("OpenDoor2");
                    ThisTrigger.SetActive(false);
                    DoorOpenSound.Play();
                    Action = false;
                    CharacterStats.Instance.currentMoney = CharacterStats.Instance.currentMoney - 500;
                }
                CharacterStats.Instance.currentArena = 2;
            }
        }

    }
}
