using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public AudioSource DoorOpenSound;
    public bool Action = false;

    [SerializeField] private GameObject doorObj;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(CharacterStats.Instance.currentMoney >= 100)
            {
                if (Action == true)
                {
                    Instruction.SetActive(false);
                    AnimeObject.GetComponent<Animator>().Play("DoorOpen");
                    ThisTrigger.SetActive(false);
                    DoorOpenSound.Play();
                    Action = false;
                    CharacterStats.Instance.currentMoney = CharacterStats.Instance.currentMoney - 100;
                }

                CharacterStats.Instance.currentArena = 1;
                Debug.Log(CharacterStats.Instance.currentArena);
            }
           
        }

    }
}

