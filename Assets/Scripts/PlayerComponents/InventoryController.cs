using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.Events;

public class InventoryController : MonoBehaviour
{
    public int money;
    public List<ItemData> items;
    public List<ItemData> equippedItems;

    public void AddItem(ItemData item)
    {
        items.Add(item);
        
        onInventoryChanged?.Invoke();
    }
    
    public void RemoveItem(ItemData item)
    {
        if (!items.Contains(item)) return;
        
        items.Remove(item);
        
        onInventoryChanged?.Invoke();
    }

    public void EquipItem(int index)
    {
        var itemData = items[index];

        if (HasItemEquipped(itemData))
        {
            equippedItems.Remove(itemData);
            onEquipmentChanged?.Invoke();
            return;
        }
        
        for (var i = 0; i < equippedItems.Count; i++)
        {
            if (equippedItems[i].type != itemData.type) continue;
            
            equippedItems.RemoveAt(i);
            break;
        }
        
        equippedItems.Add(itemData);
        onEquipmentChanged?.Invoke();
    }

    public bool HasItem(ItemData item) => items.Contains(item);

    public bool HasMoney(int amount) => money >= amount;

    public bool HasItemEquipped(ItemData item) => equippedItems.Contains(item);

    public void ChangeMoney(int amount)
    {
        money += amount;
        money = money < 0 ? 0 : money;
        
        onMoneyChanged?.Invoke();
    }

    [Header("Events")]
    public UnityEvent onInventoryChanged;
    public UnityEvent onMoneyChanged;
    public UnityEvent onEquipmentChanged;
}
