using System.Collections.Generic;
using Data;
using PlayerComponents;
using UI;
using UnityEngine;

namespace NpcComponents
{
    public class NpcShopController : NpcDialogueController
    {
        [SerializeField] private ItemData[] _shopList;
        private ShopUI _shopUI;
        
        public override void Awake()
        {
            base.Awake();
            _shopUI = GameObject.Find("Canvas").transform.Find("ShopUI").GetComponent<ShopUI>();
        }

        public override void DisplayDialogue(InteractionController interactionController)
        {
            if (dialogue.Length > 0)
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

        private void DisplayShop()
        {
            interacting = true;
            _shopUI.DisplayUI(_shopList);
            _shopUI.onWindowClose.AddListener(DisableInteraction);
        }

        private void DisableInteraction()
        {
            interacting = false;
            _shopUI.onWindowClose.RemoveListener(DisableInteraction);
        }
    }
}
