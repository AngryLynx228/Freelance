using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[System.Serializable]
public class InventorySlot //Реализация колличества предмета с помощью доп структуры
{
    public ItemData item;
    public int count;

    public InventorySlot(ItemData _item)
    {
        item = _item;
        count = _item.count;
    }

    public void AddCount(int _value)
    {
        count += _value;
    }
}

[CreateAssetMenu(fileName = "New ItemData", menuName = "Inventory System/Inventory", order = 51)]

public class Inventory : ScriptableObject
{
    public enum InventoryActions
    {
        add,
        remove
    }
    public InventoryActions iAction;

    public List<InventorySlot> container = new List<InventorySlot>();//Массив предметов



    public void InventoryAction(InventoryActions _iAction, ItemData _item)
    {
        switch (_iAction)
        {
            case InventoryActions.add:
                AddItem(_item, _item.count);
                break;
            case InventoryActions.remove:
                RemoveItem(_item, _item.count);
                break;
            default:
                break;
        }
    }

    public void AddItem (ItemData _item, int _count)
    {
        bool hasItem = false;
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == _item && _item.stackable)
            {
                container[i].AddCount(_count);
                GameManager.instance.GUIManager.AddCount(_item, container[i].count);

                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            container.Add(new InventorySlot(_item));
            GameManager.instance.GUIManager.AddSlot(_item, _item.count);
        }
    }

    public void RemoveItem(ItemData _item, int _count)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item.itemName == _item.itemName)
            {
                if (container[i].count > 1)
                {
                    container[i].count -= _count;
                }
                else
                {
                    container.RemoveAt(i);
                }
            }
        }
    }
}
