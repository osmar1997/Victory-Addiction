using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    private Animator anim;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 7.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    float turnSmoothVelocity;
    public GameObject sword;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    public void EnableSword()
    {
        sword.GetComponent<BoxCollider>().enabled = true;
    }

    public void DisableSword()
    {
        sword.GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("transition", 1);
        }
        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("transition", 0);
        }

        if (Input.GetKey(KeyCode.M))
        {
            anim.SetInteger("transition", 2);
        }
       
        if (Input.GetKeyUp(KeyCode.M))
        {
            anim.SetInteger("transition", 0);
        }
       
        if (Input.GetKey(KeyCode.N))
        {
            anim.SetInteger("transition", 3);
        }
        
        if (Input.GetKeyUp(KeyCode.N))
        {
            anim.SetInteger("transition", 0);
        }
       
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
