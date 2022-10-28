using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemControls : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    public float speed;
    public float rotSpeed;
    public float gravity;
    private float rot;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        ;
    }

    void move()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed;
                anim.SetInteger("Transition", 1);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("Transition", 0);
            }

            //Defesa
            if (Input.GetKey(KeyCode.N))
            {

                anim.SetInteger("Transition", 2);
            }
            if (Input.GetKeyUp(KeyCode.N))
            {
                anim.SetInteger("Transition", 0);
            }

            //Ataque
            if (Input.GetKey(KeyCode.M))
            { 
                anim.SetInteger("Transition", 6);    
            }
            if (Input.GetKeyUp(KeyCode.M))
            {
                anim.SetInteger("Transition", 0);
            }
            
            //cambalhota
            if (Input.GetKey(KeyCode.B))
            { 
                anim.SetInteger("Transition", 15);
                
            }
            

            //Andar para tras

            if (Input.GetKey(KeyCode.S))
            {
                moveDirection = -Vector3.forward * speed;
                anim.SetInteger("Transition", 11);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("Transition", 0);
            }

            //Rodar Dir
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("Transition", 8);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetInteger("Transition", 0);
            }

            //Rodar Esq
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("Transition", 9);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetInteger("Transition", 0);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);

    }
}
