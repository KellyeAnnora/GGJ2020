using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runemark.DialogueSystem
{
    public class DialogueInterface : MonoBehaviour
    {
        DialogueBehaviour dialogue;
        Transform player;
        DialogueFlow flow;

        private void Start()
        {
            dialogue = GetComponent<DialogueBehaviour>();
            flow = dialogue.Conversation;

            player = GameObject.FindWithTag("Player").transform;
        }

        public void DialogueOnInteraction()
        {
            Debug.Log("Starting dialogue with " + gameObject.name);
            dialogue.StartDialogue(player);
        }

        public void DialogueClose()
        {
            Debug.Log("Ending dialogue with " + gameObject.name);
            dialogue.StopDialogue(flow);
        }
    }
}


