using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{


    /*  public Transform cam;

      public float speed = 6f;
      public float turnSmoothTime = 0.1f;
    */

    public CharacterController controller;
    private Animator anim;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;





    float turnSmoothVelocity;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    /* void Update()
     {
         float horizontal = Input.GetAxisRaw("Horizontal");
         float vertical = Input.GetAxisRaw("Vertical");
         Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

         if (direction.magnitude>= 0.1f)
         {
             float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
             float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
             transform.rotation = Quaternion.Euler(0f, angle, 0f);

             Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
             controller.Move(moveDir.normalized * speed * Time.deltaTime);
         }

         if (EventSystem.current.IsPointerOverGameObject())
         {
             return;
         }


         if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
         {
             anim.SetInteger("transition", 1);
         }
         if (Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S))
         {
             anim.SetInteger("transition", 0);
         }

         if (Input.GetKey(KeyCode.M) )
         {
             anim.SetInteger("transition", 2);
         }
         if (Input.GetKeyUp(KeyCode.M) )
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

     }*/
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
