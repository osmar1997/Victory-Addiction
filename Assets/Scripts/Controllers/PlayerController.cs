using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AICharacterController
{
    float distance = 0;

    [SerializeField] public Camera camera;

    private Vector3 currentPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Calculate where the player clicked 
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if (Physics.Raycast(ray, out hitPoint))
            {
                //Tell ai script to move to this position
                SetDestination(hitPoint.point);

                ResetAnimationState2("idle");

                SetAnimationState("walk");
                currentPos = hitPoint.point;
            }
          
        }

        //Check if the player finish its movement to make in go idle
        distance = Vector3.Distance(transform.position, currentPos);
        if (distance <= 0.5f)
        {
            SetAnimationState("idle");
        }
        else
        {

            var targetRotation = Quaternion.LookRotation(new Vector3(currentPos.x, 0, currentPos.z) - character.transform.position);

            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, targetRotation, 5 * Time.deltaTime);
        }
    }
}
