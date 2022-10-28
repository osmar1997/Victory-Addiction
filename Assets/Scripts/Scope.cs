using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;

    public GameObject scopeOverlay;
    
    private bool isScoped = false;

    private int cameraFovInit = 60;
    private int onScopeCameraFov = 30;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scope", isScoped);

            if (isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnScoped();
        }
    }
    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);

        foreach (var item in GetComponentsInChildren<MeshRenderer>())
        {
            item.enabled = true;
        }

        GetComponentInParent<Camera>().fieldOfView = cameraFovInit;

    }
    IEnumerator OnScoped() 
    {
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);

        foreach (var item in GetComponentsInChildren<MeshRenderer>())
        {
            item.enabled = false;
        }

        GetComponentInParent<Camera>().fieldOfView = onScopeCameraFov;
    }

}
