
using UnityEngine;


/*
Este componente � para todos os objetos que o jogador pode
interagir com inimigos, itens, etc.
para ser usado como uma classe base.
*/
public class Interacao : MonoBehaviour
{

	public float radius = 3f;               // Qu�o perto precisamos estar para interagir?
	public Transform interactionTransform;  // A transforma��o de onde interagimos caso voc� queira compensar

	bool isFocus = false;   // Este interativo est� sendo focado no momento?
	public Transform player;      // Refer�ncia � transforma��o do jogador

	bool hasInteracted = false; // J� interagimos com o objeto?

	public virtual void Interact()
	{
		// This method is meant to be overwritten
		Debug.Log("Interacting with " + transform.name);
	}

	void Update()
	{
		// If we are currently being focused
		// and we haven't already interacted with the object
		if (isFocus && !hasInteracted)
		{
			// If we are close enough
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			if (distance <= radius)
			{
				// Interact with the object
				Interact();
				hasInteracted = true;
			}
		}
	}

	// Called when the object starts being focused
	public void OnFocused(Transform playerTransform)
	{
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	// Called when the object is no longer focused
	public void OnDefocused()
	{
		isFocus = false;
		player = null;
		hasInteracted = false;
	}

	// Draw our radius in the editor
	void OnDrawGizmosSelected()
	{
		if (interactionTransform == null)
			interactionTransform = transform;

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}
