using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Makes the camera follow the player */
public class CameraController : MonoBehaviour
{
	public Transform target;
	public float currentZoom = 10f;
	public Vector3 offset;
	public float pitch = 2f;
	
	void LateUpdate()
	{
		transform.position = target.position - offset * currentZoom;
		transform.LookAt(target.position + Vector3.up * pitch);

	}

}
