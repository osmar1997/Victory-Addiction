using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 5f;
    public float bulletDamage = 10f;
    public float enemyHealth = 30f;

    public Transform target;
    NavMeshAgent agent;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootingPos;
    bool isShooting = false;

    public GameObject enemieSpawn;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("playerBullet"))
        {
            enemyHealth -= 10;

            if (enemyHealth <= 0)
            {
                Destroy(target, 1f);
                //Implementar o desaparecimento do enimigo
            }
        }
    }
    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, shootingPos.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
        Destroy(newBullet, 1f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        enemieSpawn = GameObject.FindGameObjectWithTag("EnemySpawn");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position); //Faz o enemy seguir o player

            if (isShooting == false) 
            {
                InvokeRepeating("Shoot", 1, 0.5f); 
                isShooting = true;
            } 
            
        }
        else
        {
            CancelInvoke("Shoot");
            isShooting = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
