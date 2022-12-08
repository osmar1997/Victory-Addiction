using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _playerMovement;
    public GameObject Sword;

    [SerializeField]
    private Animator _anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (_playerMovement.enabled == true)
        {
            if (_playerMovement.IsMoving == false)
            {
                if (Input.GetKey(KeyCode.N))
                {
                    _anim.SetInteger("transition", 3);
                }

                if (Input.GetKeyUp(KeyCode.N))
                {
                    _anim.SetInteger("transition", 0);
                }
            }
        }
    }
}
