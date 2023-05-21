using System;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        private InventoryController _inventoryController;
        private InventorySlotUI[] _slotUIs;

        private void Awake()
        {
            _inventoryController = GameObject.Find("Player").GetComponent<InventoryController>();
        
            _inventoryController.onInventoryChanged.AddListener(UpdateUI);
            _inventoryController.onEquipmentChanged.AddListener(UpdateUI);
            
            var slotsContainer = transform.Find("InventoryWindow").Find("Content");
            _slotUIs = new InventorySlotUI[slotsContainer.childCount];

            for (var i = 0; i < _slotUIs.Length; i++)
            {
                _slotUIs[i] = slotsContainer.GetChild(i).GetComponent<InventorySlotUI>();
                _slotUIs[i].SetSlotIndex(i);
            }
            
            UpdateUI();
        }

        public void EquipItem(int index) => _inventoryController.EquipItem(index);

        public void UpdateUI()
        {
            for (var i = 0; i < _slotUIs.Length; i++)
            {
                var displaySlot = i < _inventoryController.items.Count;
                _slotUIs[i].gameObject.SetActive(displaySlot);
                
                if(!displaySlot) continue;

                var itemData = _inventoryController.items[i];
                _slotUIs[i].UpdateUIContent(itemData.icon, itemData.color);
                _slotUIs[i].DisplayEquippedIcon(_inventoryController.HasItemEquipped(itemData));
            }
        }

        private void OnDisable()
        {
            onCloseInventory?.Invoke();
        }

        [Header("Events")]
        public UnityEvent onCloseInventory;
    }
}
