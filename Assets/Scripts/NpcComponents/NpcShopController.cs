using System.Collections.Generic;
using Data;
using PlayerComponents;
using UI;
using UI.Shop;
using UnityEngine;

namespace NpcComponents
{
    public class NpcShopController : NpcDialogueController
    {
        [SerializeField] private ItemData[] _shopList;
        private ShopUI _shopUI;

        private InteractionController _cachedInteractionController;
        
        public override void Awake()
        {
            base.Awake();
            _shopUI = GameObject.Find("Canvas").transform.Find("ShopUI").GetComponent<ShopUI>();
        }

        public override void DisplayDialogue(InteractionController interactionController)
        {
            _cachedInteractionController = interactionController;
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
            _shopUI.UpdateUI(_shopList);
            _shopUI.onWindowClose.AddListener(DisableInteraction);
        }

        private void DisableInteraction()
        {
            interacting = false;
            _cachedInteractionController.EnableMovement(true);
            _shopUI.onWindowClose.RemoveListener(DisableInteraction);
        }
    }
}
