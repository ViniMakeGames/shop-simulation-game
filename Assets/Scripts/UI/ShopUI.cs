using System;
using Data;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class ShopUI : MonoBehaviour
    {
        private ItemData[] _items;
        private ShopSlotUI[] _slotUis;
        private InventoryController _inventory;

        private void Awake()
        {
            _inventory = GameObject.Find("Player").transform.GetComponent<InventoryController>();
            
            var slotsContainer = transform.Find("Content");
            _slotUis = new ShopSlotUI[slotsContainer.childCount];

            for (var i = 0; i < _slotUis.Length; i++)
            {
                _slotUis[i] = slotsContainer.GetChild(i).GetComponent<ShopSlotUI>();
                _slotUis[i].SetSlotIndex(i);
            }
        }

        public void UpdateUI() => UpdateUI(_items);
        public void UpdateUI(ItemData[] items)
        {
            _items = items;
            gameObject.SetActive(true);

            for (var i = 0; i < _slotUis.Length; i++)
            {
                var displaySlot = i < items.Length && !_inventory.HasItem(items[i]);
                
                _slotUis[i].gameObject.SetActive(displaySlot);
                
                if(!displaySlot) continue;
                
                var itemData = items[i];
                var priceColor = _inventory.HasMoney(itemData.price) ? Color.white : Color.red;
                _slotUis[i].UpdateUIContent(itemData.icon, itemData.color, itemData.price.ToString(), priceColor);
            }
        }

        public void CloseWindow()
        {
            gameObject.SetActive(false);
            onWindowClose?.Invoke();
        }

        public void SelectSlot(int slotIndex)
        {
            var itemData = _items[slotIndex];
            
            if (!_inventory.HasMoney(itemData.price)) return;
            
            _inventory.ChangeMoney(-itemData.price);
            _inventory.AddItem(itemData);
            
            UpdateUI();
        }
        
        [Header("Events")]
        public UnityEvent onWindowClose;
    }
}
