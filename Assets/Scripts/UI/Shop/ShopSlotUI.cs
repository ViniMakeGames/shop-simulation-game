using TMPro;
using UnityEngine;

namespace UI.Shop
{
    public class ShopSlotUI : SlotUIBase
    {
        public TextMeshProUGUI priceText;

        private ShopUI _shopUI;

        private void Awake()
        {
            _shopUI = transform.parent.parent.GetComponent<ShopUI>();
        }

        public void UpdateUIContent(Sprite icon, Color iconColor, string price, Color priceColor)
        {
            SetIcon(icon);
            SetIconColor(iconColor);
            SetPriceText(price);
            SetPriceTextColor(priceColor);
        }

        public void SetPriceText(string content) => priceText.text = content;
        public void SetPriceTextColor(Color color) => priceText.color = color;

        public override void OnClick()
        {
            _shopUI.SelectSlot(slotIndex);
        }
    }
}
