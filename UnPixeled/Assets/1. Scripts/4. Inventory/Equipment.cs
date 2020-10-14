using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New ItemData", menuName = "Inventory System/Equipment", order = 51)]
public class Equipment : ScriptableObject
{
    public ItemData weaponSlot;
    public GameObject weapon;

    public enum EquipmentActions
    {
        equip,
        upequip,
        swap
    }
    EquipmentActions equipmentActions;

    public void EquipmentAction (EquipmentActions action, ItemData _item)
    {
        switch (action)
        {
            case EquipmentActions.equip:
                Equip(_item);
                break;
            case EquipmentActions.upequip:
                UpEqip(_item);
                break;
            case EquipmentActions.swap:
                break;
            default:
                break;
        }
    }

    public void Equip (ItemData _item)
    {
        switch (_item.itemType)
        {
            case ItemData.ItemType.etc:
                break;

            case ItemData.ItemType.weapon:
                weaponSlot = _item;
                weapon = _item.prefab;
                Instantiate(weapon, GameManager.instance.playerController.rightHand.transform);
                GameManager.instance.playerController.weaponCollider = GameManager.instance.playerController.rightHand.transform.GetChild(0).GetComponent<BoxCollider>();
                GameManager.instance.playerController.weaponCollider.enabled = false;
                GameManager.instance.GUIManager.AddEquip(_item);
                break;

            case ItemData.ItemType.armour:
                break;

            case ItemData.ItemType.consumable:
                break;

            default:
                break;
        }
    }

    public void UpEqip (ItemData _item)
    {
        switch (_item.itemType)
        {
            case ItemData.ItemType.etc:
                break;

            case ItemData.ItemType.weapon:
                GameManager.instance.playerController.weaponCollider = null;
                Destroy(GameManager.instance.playerController.rightHand.transform.GetChild(0).gameObject);
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
