using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private int _slotIndex;

    private ShopUI _shopUI;

    private void Awake()
    {
        _shopUI = transform.parent.parent.GetComponent<ShopUI>();
    }

    public void SetSlotIndex(int index) => _slotIndex = index;

    public void UpdateUIContent(Sprite icon, Color iconColor, string price, Color priceColor)
    {
        SetIcon(icon);
        SetIconColor(iconColor);
        SetPriceText(price);
        SetPriceTextColor(priceColor);
    }
    
    public void SetIcon(Sprite icon) => _image.sprite = icon;
    public void SetIconColor(Color color) => _image.color = color;
    
    public void SetPriceText(string content) => _priceText.text = content;
    public void SetPriceTextColor(Color color) => _priceText.color = color;

    public void OnClick()
    {
        _shopUI.SelectSlot(_slotIndex);
    }
}
