using System;
using UnityEngine;

namespace UI.Inventory
{
    public class InventorySlotUI : SlotUIBase
    {
        private InventoryUI _inventoryUI;

        private void Awake()
        {
            _inventoryUI = transform.parent.parent.parent.GetComponent<InventoryUI>();
        }

        public GameObject equippedIcon;
    
        public void DisplayEquippedIcon(bool value) => equippedIcon.SetActive(value);

        public override void OnClick()
        {
            _inventoryUI.EquipItem(slotIndex);
        }
    }
}
