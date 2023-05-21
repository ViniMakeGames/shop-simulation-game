using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _priceText;

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
    
}
