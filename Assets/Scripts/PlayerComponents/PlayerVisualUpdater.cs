using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class PlayerVisualUpdater : MonoBehaviour
{
    private InventoryController _inventory;
    private CharacterVisualController _visualController;

    private void Awake()
    {
        _inventory = GetComponent<InventoryController>();
        _inventory.onEquipmentChanged.AddListener(UpdateVisual);
        _visualController = transform.GetChild(0).GetComponent<CharacterVisualController>();
    }

    private void Start()
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        _visualController.SetGlasses(_inventory.GetEquippedItemByType(ItemType.Glasses));
        _visualController.SetHat(_inventory.GetEquippedItemByType(ItemType.Hat));
        _visualController.SetTop(_inventory.GetEquippedItemByType(ItemType.Top));
        _visualController.SetPants(_inventory.GetEquippedItemByType(ItemType.Pants));
        _visualController.SetShoes(_inventory.GetEquippedItemByType(ItemType.Shoes));
    }
}
