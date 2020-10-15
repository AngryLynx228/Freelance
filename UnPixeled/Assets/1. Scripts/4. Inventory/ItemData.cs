using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Inventory System/Item", order = 51)]
public class ItemData : ScriptableObject
{
    public GameObject prefab;
    public Sprite itemIcon; // Иконка
    public string itemName; // Название
    public bool stackable; // Стакуется?
    public int count; // Количество
    public enum ItemType // Тип предмета
    {
        etc,
        weapon,
        armour,
        consumable
    }
    public ItemType itemType;

    

    public Sprite ItemIcon
    {
        get
        {
            return itemIcon;
        }
    }

    public string ItemName
    {
        get
        {
            return itemName;
        }
    }

    public bool Stackable
    {
        get
        {
            return stackable;
        }
    }

    public int Count
    {
        get
        {
            return count;
        }
    }

    public GameObject Prefab
    {
        get
        {
            return prefab;
        }
    }
}
