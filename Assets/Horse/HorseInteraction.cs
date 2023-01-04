using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<PlayerController>().isMounted)
        {
            other.GetComponent<PlayerController>().SwitchToMount(true);

            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

            other.GetComponent<PlayerController>().isMounted = true;
        }
    }
}
