using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Inventory System/Item", order = 51)]
public class ItemData : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
    public bool stackable;
    public int count;
    public enum ItemType
    {
        etc,
        weapon,
        armour,
        consumable
    }
    public ItemType itemType;
    public GameObject prefab;
    

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
