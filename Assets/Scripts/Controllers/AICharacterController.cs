using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterController : MonoBehaviour 
{
    [SerializeField] protected Transform character;
    [SerializeField] protected Animator animator;

    protected NavMeshAgent agent;

    protected string animationState;

    protected int animationValue;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        if(agent)
        agent.updateRotation = false;


    }

    protected virtual void Start()
    {
        SetAnimationState("Idle");
    }

    protected virtual void Update()
    {
        float speed = agent.velocity.magnitude;

        if (agent.velocity != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(agent.velocity, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);
        }

        animator.SetFloat("WalkingSpeed", speed);
    }


    public bool HasReached(Vector3 destination, float maxDistance = 1f)
    {
        Vector3 offset = destination - transform.position;
        float sqrLen = offset.sqrMagnitude;

        if (sqrLen <= maxDistance * maxDistance)
        {
            return true;
        }

        //if (Vector3.Distance(transform.position, destination) <= maxDistance)
        //return true;

        return false;
    }

    public void Move(Vector3 position)
    {
        if (!agent.isOnNavMesh || !agent.Warp(position))
        {
            transform.position = position;
        }
    }

    public void Stop()
    {
        SetDestination(transform.position);
    }

    public bool SetDestination(Vector3 position)
    {
        if (agent && agent.isOnNavMesh)
        {
            Vector3 endPath = agent.pathEndPosition;

            //if (Vector3.Distance(endPath, position) > 1f)
            //{
            //    return agent.SetDestination(position);
            //}
            agent.SetDestination(position);

            return true;
        }

        return false;
    }


    public void SetAnimationState(string state)
    {
        print(state);
        if (state != animationState)
        {
            animationState = state;

            animator.SetTrigger(state);
        }
    }
    public void SetAnimationValue(int value)
    {
        if (value != animationValue)
        {
            animationValue = value;

            animator.SetInteger("animation", value);
        }
    }
    public void SetAnimationState2(int state)
    {
        print(state);
        animator.SetInteger("transition", state);     
    }
    public void ResetAnimationState2(string state)
    {
        print(state);
        animator.ResetTrigger(state);
    }
    public bool CheckAnimationEnded(string anim)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(anim))
        {
            return true;
        }
        return false;
    }
}
