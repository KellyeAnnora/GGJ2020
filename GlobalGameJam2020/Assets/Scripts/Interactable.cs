using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runemark.DialogueSystem;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    DialogueInterface dialogue;

    private void Start()
    {
        dialogue = GetComponent<DialogueInterface>();
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
        dialogue.DialogueOnInteraction();
    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
        dialogue.DialogueClose();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}




