using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor2 : MonoBehaviour
{
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
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
            AnimeObject.GetComponent<Animator>().Play("CloseDoor2");
            ThisTrigger.SetActive(false);
            DoorCloseSound.Play();
            Action = false;
        }
    }
}
