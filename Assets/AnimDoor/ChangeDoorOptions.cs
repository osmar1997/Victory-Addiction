using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDoorOptions : MonoBehaviour
{
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public GameObject ThisTriggerCloseDoor;
    public GameObject ThisTriggerOpenDoor;
    public AudioSource DoorCloseSound;
    public bool Action = false;
    private GameObject enemyRef;
    void Start()
    {
        enemyRef = Resources.Load<GameObject>("Enemy");

    }

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
            if(CharacterStats.Instance.currentArena == 2)
            {
                Debug.Log("j");
                AnimeObject.GetComponent<Animator>().Play("CloseDoor2");
            }
            if (CharacterStats.Instance.currentArena == 1)
            {
                AnimeObject.GetComponent<Animator>().Play("CloseDoor");
            }
            
            ThisTriggerOpenDoor.SetActive(true);
            ThisTriggerCloseDoor.SetActive(true);
            ThisTrigger.SetActive(false);
            Action = false;
            DoorCloseSound.Play();
            //RespawnEnemy();
        }
    }
    void RespawnEnemy()
    {
        GameObject enemyClone = (GameObject)Instantiate(enemyRef);
        enemyClone.transform.position = transform.position;

    }
}

