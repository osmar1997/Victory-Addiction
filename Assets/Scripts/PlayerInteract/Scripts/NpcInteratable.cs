using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteratable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;

    private Animator animator;
    private NPCHeadLookAt npcHeadLookAt;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        npcHeadLookAt = GetComponent<NPCHeadLookAt>();

    }

    public void Interact(Transform interactorTransform)
    {
        ChatBubble.Create(transform.transform, new Vector3(-.3f, 1.7f, 0f), ChatBubble.IconType.Happy, GetInteractText());
        float playerHeight = 1.7f;
        npcHeadLookAt.LookAtPosition(interactorTransform.position + Vector3.up * playerHeight);

        //animator.SetTrigger("Talk");

    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}