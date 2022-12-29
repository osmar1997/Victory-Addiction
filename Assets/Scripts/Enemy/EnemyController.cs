using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 20f;

    Transform target;
    NavMeshAgent agent;
    private Animator anim;
    public bool isAlive;
    public GameObject armcollider;

    private bool attack;

    [SerializeField] public bool isBoss;
    [SerializeField] public bool hasRegenerated;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

     
        if (distance <= lookRadius && isAlive)
        {
            agent.SetDestination(target.position);
            anim.SetInteger("TransitionEnemy", 1);

            if (distance <= (agent.stoppingDistance = 2f))
            {
                //im.SetInteger("TransitionEnemy", 2);
                if(!attack)
                {
                    attack = true;
                    StartCoroutine(AttackSeq());
                }

                // Attack the target
                FaceTarget();

                GetComponent<Patrolling>().patroling = false;
            }

        }
        else
        {
            anim.SetInteger("TransitionEnemy", 0);
        }

    }

    IEnumerator AttackSeq()
    {
        print("aqui");
        anim.SetTrigger("attack");

        yield return new WaitForSeconds(1);

        attack = false;
    }

    public void EnableArm()
    {
        armcollider.GetComponent<BoxCollider>().enabled = true;
    }

    public void DisableArm()
    {
        armcollider.GetComponent<BoxCollider>().enabled = false;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


}