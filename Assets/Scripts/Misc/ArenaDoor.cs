using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaDoor : MonoBehaviour
{
    public Transform PlayerSpawnPosition;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("player in position");
            other.gameObject.transform.GetChild(1).gameObject.GetComponent<ThirdPersonMovement>().enabled = false;

            other.transform.position = PlayerSpawnPosition.position;
            other.gameObject.transform.GetChild(1).gameObject.GetComponent<ThirdPersonMovement>().enabled = true;

        }

    }
}
