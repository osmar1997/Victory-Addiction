using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDoorOptions : MonoBehaviour
{
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public GameObject ThisTriggerCloseDoor;
    public GameObject ThisTriggerOpenDoor;
    public AudioSource DoorCloseSound;
    public bool Action = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Action = false;
    }
    void Update()
    {
        if (Action == true)
        {
            AnimeObject.GetComponent<Animator>().Play("CloseDoor");
            ThisTriggerOpenDoor.SetActive(true);
            ThisTriggerCloseDoor.SetActive(true);
            ThisTrigger.SetActive(false);
            Action = false;
            DoorCloseSound.Play();
        }
    }
}

