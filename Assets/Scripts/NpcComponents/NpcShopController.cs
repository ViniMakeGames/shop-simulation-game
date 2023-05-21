using System.Collections.Generic;
using PlayerComponents;
using UI;
using UnityEngine;

namespace NpcComponents
{
    public class NpcShopController : NpcDialogueController
    {
        public override void DisplayDialogue(InteractionController interactionController)
        {
            if (dialogue.Count > 0)
            {
                base.DisplayDialogue(interactionController);
            }
            else
            {
                DisplayShop();
            }
        }

        public override void NextDialogue(InteractionController interactionController)
        {
            var hasDialogue = dialogueBox.NextDialogue();

            if (!hasDialogue)
            {
                DisplayShop();
            }
        }

        public void DisplayShop()
        {
            interacting = true;
            
        }
    }
}
