using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera playerCamera;

    [SerializeField] public GameObject player;

    [SerializeField] public GameObject horse;


    public void SwitchCameraTarget()
    {
        playerCamera.m_Follow = horse.transform;
        playerCamera.m_LookAt = horse.transform;

    }
}
