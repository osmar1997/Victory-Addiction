using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : AICharacterController
{
    float distance = 0;

    [SerializeField] public Camera camera;

    private Vector3 currentPos;

    [SerializeField] private GameObject mount;
    [SerializeField] private Animator mountAnim;

    public bool isMounted;

    private void Start()
    {
        //SwitchToMount(false);
    }

    // Update is called once per frame
    public virtual void Update()
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

            //character.transform.rotation = Quaternion.Slerp(character.transform.rotation, targetRotation, 5 * Time.deltaTime);

            //mount.transform.rotation = Quaternion.Slerp(character.transform.rotation, targetRotation, 5 * Time.deltaTime);

            Vector3 worldLookDirection = currentPos - character.transform.position;
            Vector3 localLookDirection = character.transform.InverseTransformDirection(worldLookDirection);
            localLookDirection.y = 0;
            character.transform.forward = character.transform.rotation * localLookDirection;

            mount.transform.forward = character.transform.rotation * localLookDirection;

        }
        if (distance > 0)
        {
            mountAnim.SetBool("walk", true);
        }
        if (distance < .1f)
        {
            mountAnim.SetBool("walk", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchToMount(false);
        }

    }

    public void SwitchToMount(bool value)
    {
        mount.SetActive(value);
        character.gameObject.SetActive(!value);

        GameObject horseInteraction = GameObject.FindGameObjectWithTag("HorseInteraction");
        horseInteraction.transform.position = transform.position;
        horseInteraction.transform.rotation = mount.transform.rotation;
        horseInteraction.GetComponentInChildren<SkinnedMeshRenderer>().enabled = !value;
        if(value == true)
            GetComponent<NavMeshAgent>().speed=6;
        else
        {
            StartCoroutine(MountCountdown());
            GetComponent<NavMeshAgent>().speed = 3;

        }
    }

    IEnumerator MountCountdown()
    {
        yield return new WaitForSeconds(2);

        isMounted = false;
    }
}
