
using UnityEngine;

public class Interacao : MonoBehaviour
{
    public float radius = 3f;

    void OnDrawGizmoSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
