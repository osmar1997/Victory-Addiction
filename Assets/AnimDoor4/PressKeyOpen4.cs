using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyOpen4: MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (CharacterStats.Instance.currentXp >= 4)
            {
                if (Action == true)
                {
                    Instruction.SetActive(false);
                    AnimeObject.GetComponent<Animator>().Play("OpenDoor4");
                    ThisTrigger.SetActive(false);
                    DoorOpenSound.Play();
                    Action = false;
                   
                }
                CharacterStats.Instance.currentArena = 4;
            }
        }

    }
}

