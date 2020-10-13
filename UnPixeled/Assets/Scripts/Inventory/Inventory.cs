﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> inventory;
    public List<int> inventoryCount;
    public ItemData test1;
    public ItemData test2;
    public ItemData test3;

    public enum InventoryActions
    {
        addItem,
        removeItem,
        useItem
    }
    public InventoryActions inventoryActions;


    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            InventoryAction(InventoryActions.addItem, test1);
        }
    }

    public void InventoryAction (InventoryActions action, ItemData item)
    {
        switch (action)
        {
            case InventoryActions.addItem:
                AddItem(item);
                break;
            case InventoryActions.removeItem:
                RemoveItem(item);
                break;
            case InventoryActions.useItem:

                break;
            default:
                break;
        }
    }

    public void AddItem (ItemData item)
    {
        if (item.stackable == true && CheckSlot(item) == true)
        {
            inventoryCount[StackIndex(item)] += item.Count;

            Debug.Log("______Stacked______");
            for (int b = 0; b < inventory.Count; b++)
            {
                Debug.Log((inventory[b].itemName, " ", inventoryCount[b]));
            }
        }
        else
        {
            inventory.Add(item);
            inventoryCount.Add(item.Count);

            Debug.Log("_______Added_______");
            for (int b = 0; b < inventory.Count; b++)
            {
                Debug.Log((inventory[b].itemName, " ", inventoryCount[b]));
            }
        }
    }

    public void RemoveItem(ItemData item)
    {
        if (CheckSlot(item) == true && inventoryCount[StackIndex(item)] > 1)
        {
            inventoryCount[StackIndex(item)] -= 1;
            Debug.Log("_______Removed - 1 ________");
            for (int b = 0; b < inventory.Count; b++)
            {
                Debug.Log((inventory[b].itemName, " ", inventoryCount[b]));
            }
        }
        else
        {
            inventory.RemoveAt(StackIndex(item));
            inventoryCount.RemoveAt(StackIndex(item));

            Debug.Log("_______Removed Compleetly________");
            for (int b = 0; b < inventory.Count; b++)
            {
                Debug.Log((inventory[b].itemName, " ", inventoryCount[b]));
            }
        }
    }

    bool CheckSlot(ItemData item)
    {
        bool stack = false;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (item.itemName == inventory[i].itemName)
            {
                stack = true;
            }
        }
        return stack;
    }

    int StackIndex(ItemData item)
    {
        int index = 0;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (item.itemName == inventory[i].itemName)
            {
                index = i;
            }
        }
        return index;
    }
}