using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAttack : MonoBehaviour
{
    [SerializeField] private int damage;

    private bool resetArm;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !resetArm)
        {
            print("The Enemy is attacking the Player");
            other.GetComponent<CharacterStats>().TakeDamage(damage);
            resetArm = true;
            StartCoroutine(ResetArm());
        }
    }

    IEnumerator ResetArm()
    {
        yield return new WaitForSeconds(1);

        resetArm = false;
    }
}
