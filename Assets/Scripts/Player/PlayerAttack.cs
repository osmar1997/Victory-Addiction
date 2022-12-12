using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : AICharacterController
{
    [SerializeField]
    private PlayerMovement _playerMovement;
    public GameObject Sword;

    [SerializeField] private bool attack;

    // Start is called before the first frame update
    void Start()
    {
        DisableSword();
    }
    public void EnableSword()
    {
        Sword.GetComponent<BoxCollider>().enabled = true;
        _playerMovement.enabled = false;
    }

    public void DisableSword()
    {
        Sword.GetComponent<BoxCollider>().enabled = false;
        _playerMovement.enabled = true;

    }
    // Update is called once per frame
    void Update()
    {
     
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<PlayerController>().camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if (Physics.Raycast(ray, out hitPoint))
            {
                if (hitPoint.transform.gameObject.CompareTag("Enemy"))
                {
                    if (!attack)
                    {
                        attack = true;
                        StartCoroutine(AttackSeq());
                    }

                }
            }
        }
       
    }
    IEnumerator AttackSeq()
    {
        print("esteeeee");
        SetAnimationState("attack");

        yield return new WaitForSeconds(2);
        SetAnimationState("idle");

        attack = false;
    }
}
