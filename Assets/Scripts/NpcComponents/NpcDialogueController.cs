using System;
using PlayerComponents;
using UI;
using UnityEngine;

namespace NpcComponents
{
    public class NpcDialogueController : NpcControllerBase
    {
        private DialogueBoxUI _dialogueBox;
        private bool _interacting;
        
        private void Awake()
        {
            _dialogueBox = GameObject.Find("Canvas").transform.Find("DialogueBox").GetComponent<DialogueBoxUI>();
        }

        public override void Interact(InteractionController interactionController)
        {
            if (!_interacting)
            {
                interactionController.EnableMovement(false);
                _dialogueBox.DisplayText("Hello! How are you my friend?");
                _interacting = true;
            }
            else
            {
                _interacting = _dialogueBox.NextDialogue();
                interactionController.EnableMovement(!_interacting);
            }
        }
    }
}
