using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [HideInInspector] public ItemData weaponSlot;
    [HideInInspector] public GameObject weapon; //Weapon attached to hand

    public enum EquipmentActions
    {
        equipItem,
        removeItem,
        swapItem
    }
    [HideInInspector] public EquipmentActions equpmentActions;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            weaponSlot = GetComponent<Inventory>().inventory[0];
            EquipmentAction(EquipmentActions.equipItem, weaponSlot);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            EquipmentAction(EquipmentActions.removeItem, weaponSlot);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            EquipmentAction(EquipmentActions.removeItem, weaponSlot);
            weaponSlot = GetComponent<Inventory>().inventory[0];
            EquipmentAction(EquipmentActions.equipItem, weaponSlot);
        }
    }

    public void EquipmentAction(EquipmentActions action, ItemData item)
    {
        switch (action)
        {
            case EquipmentActions.equipItem:
                EquipItem(item);
                break;
            case EquipmentActions.removeItem:
                RemoveItem(item);
                break;
            case EquipmentActions.swapItem:
                SwapItem(item);
                break;
            default:
                break;
        }
    }

    public void EquipItem (ItemData item)
    {
        switch (item.itemType)
        {
            case ItemData.ItemType.etc:
                break;
            case ItemData.ItemType.weapon:
                if (weapon == null)
                {
                    weapon = Instantiate(item.prefab, GameManager.instance.playerController.rightHand.transform);
                    GameManager.instance.playerController.weaponCollider = weapon.GetComponent<BoxCollider>();
                    GameManager.instance.playerController.weaponCollider.enabled = false;
                    GetComponent<Inventory>().InventoryAction(Inventory.InventoryActions.removeItem, item);
                }
                break;
            case ItemData.ItemType.armour:
                break;
            case ItemData.ItemType.consumable:
                break;
            default:
                break;
        }
    }

    public void SwapItem (ItemData item)
    {
        switch (item.itemType)
        {
            case ItemData.ItemType.etc:
                break;
            case ItemData.ItemType.weapon:
                break;
            case ItemData.ItemType.armour:
                break;
            case ItemData.ItemType.consumable:
                break;
            default:
                break;
        }
    }

    public void RemoveItem (ItemData item)
    {
        switch (item.itemType)
        {
            case ItemData.ItemType.etc:
                break;
            case ItemData.ItemType.weapon:
                if (weapon != null)
                {
                    GetComponent<Inventory>().InventoryAction(Inventory.InventoryActions.addItem, item);
                    Destroy(weapon);
                    weapon = null;
                }
                break;
            case ItemData.ItemType.armour:
                break;
            case ItemData.ItemType.consumable:
                break;
            default:
                break;
        }
    }
}
