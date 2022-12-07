using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;

    private bool resetSword;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !resetSword)
        {
            other.GetComponent<CharacterStats>().TakeDamage(damage);
            resetSword = true;
            StartCoroutine(ResetSword());
        }
    }

    IEnumerator ResetSword()
    {
        yield return new WaitForSeconds(1);
        resetSword = false;
    }
}
