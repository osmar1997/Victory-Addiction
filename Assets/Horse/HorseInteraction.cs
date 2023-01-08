using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseInteraction : MonoBehaviour
{
    public AudioSource itemSound;
    public AudioSource soundWalk;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<PlayerController>().isMounted)
        {
            other.GetComponent<PlayerController>().SwitchToMount(true);
            itemSound.Play();
            //soundWalk.Play();

            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

            other.GetComponent<PlayerController>().isMounted = true;
        }
    }
}
