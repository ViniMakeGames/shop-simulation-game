using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    private InventoryController _inventory;
    private void Awake()
    {
        _inventory = GameObject.Find("Player").GetComponent<InventoryController>();
        _inventory.onMoneyChanged.AddListener(UpdateUI);

        _currentAmount = _inventory.money;
        _textAmount.text = _inventory.money.ToString();
    }

    [SerializeField] private TextMeshProUGUI _textAmount;
    [SerializeField] private int _currentAmount;
    [SerializeField] private float _animationSpeed;
    
    private void UpdateUI()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateMoneyAmount());
    }

    private IEnumerator UpdateMoneyAmount()
    {
        while (_currentAmount != _inventory.money)
        {
            var t = 0f;
            while (t < 1f)
            {
                t += _animationSpeed * Time.deltaTime;
                yield return null;
            }

            _currentAmount += _currentAmount < _inventory.money ? 1 : -1;
            _textAmount.text = _currentAmount.ToString();
            yield return null;
        }
    }
}
