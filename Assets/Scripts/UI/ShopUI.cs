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

        private void Awake()
        {
            var slotsContainer = transform.Find("Content");
            _slotUis = new ShopSlotUI[slotsContainer.childCount];

            for (var i = 0; i < _slotUis.Length; i++)
            {
                _slotUis[i] = slotsContainer.GetChild(i).GetComponent<ShopSlotUI>();
            }
        }

        public void DisplayUI(ItemData[] items)
        {
            _items = items;
            gameObject.SetActive(true);

            for (var i = 0; i < _slotUis.Length; i++)
            {
                var displaySlot = i < items.Length;
                _slotUis[i].gameObject.SetActive(displaySlot);
                
                if(!displaySlot) continue;

                var item = items[i];
                
                _slotUis[i].UpdateUIContent(item.icon, item.color, item.price.ToString(), Color.white);
            }
        }

        public void CloseWindow()
        {
            gameObject.SetActive(false);
            onWindowClose?.Invoke();
        }
        
        public UnityEvent onWindowClose;
    }
}
