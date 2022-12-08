using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageStore : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject ThisTrigger;
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            if (Action == true)
              {
                Instruction.SetActive(false);
                ThisTrigger.SetActive(false);  
                Action = false;
              } 
        }
    }
}
