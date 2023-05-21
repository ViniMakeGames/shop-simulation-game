using System;
using System.Collections.Generic;
using PlayerComponents;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace NpcComponents
{
    public class NpcDialogueController : NpcControllerBase
    {
        [HideInInspector] public DialogueBoxUI dialogueBox;

        public string[] dialogue;

        public virtual void Awake()
        {
            dialogueBox = GameObject.Find("Canvas").transform.Find("DialogueBox").GetComponent<DialogueBoxUI>();
        }

        public override void Interact(InteractionController interactionController)
        {
            if (!interacting)
            {
                DisplayDialogue(interactionController);
            }
            else
            {
                NextDialogue(interactionController);
            }
        }

        public virtual void DisplayDialogue(InteractionController interactionController)
        {
            if (dialogue.Length <= 0) return;
            
            interactionController.EnableMovement(false);
            dialogueBox.DisplayText(dialogue);
            interacting = true;
        }

        public virtual void NextDialogue(InteractionController interactionController)
        {
            interacting = dialogueBox.NextDialogue();
            interactionController.EnableMovement(!interacting);

            if (!interacting)
            {
                onConversationEnd?.Invoke();
            }
        }

        [Header("Events")]
        public UnityEvent onConversationEnd;
    }
}
