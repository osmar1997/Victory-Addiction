using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public GameObject Sword;
    public void EnableSword()
    {
        Sword.GetComponent<BoxCollider>().enabled = true;
    }

    public void DisableSword()
    {
        Sword.GetComponent<BoxCollider>().enabled = false;

    }
}
