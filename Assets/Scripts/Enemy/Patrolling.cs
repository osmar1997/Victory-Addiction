using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
   public List<Vector3> points;

    public float MovingSpeed;
    public bool patroling;
    private int targetindex;
    public Animator anim;

    public void Start()
    {
        targetindex = 0;
    }
    public void Update()
    {
        anim.SetInteger("TransitionEnemy",patroling == true? 1: 0);
       if (patroling == true)
        {
            var targetposition = points[targetindex];
            transform.position = Vector3.MoveTowards(transform.position, targetposition, MovingSpeed*Time.deltaTime);
            var direction = targetposition - transform.position;
            direction.Normalize();
            transform.forward = direction;
            if (Vector3.Distance(transform.position, targetposition) <= 0.1f) {
                if (targetindex >= points.Count-1) {
                targetindex = 0;
                }
                else { targetindex += 1; }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
      foreach(var p in points)
        {
            Gizmos.DrawSphere(p, 1);
        }
    }

    public Vector3 currentPoint()
    {
        return points[targetindex];
    }
}
