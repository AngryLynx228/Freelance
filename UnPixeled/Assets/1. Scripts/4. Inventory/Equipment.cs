using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

//[CreateAssetMenu(fileName = "New ItemData", menuName = "Inventory System/Equipment", order = 51)]
public class Equipment : ScriptableObject
{
    public enum EquipmentActions
    {
        equip,
        upequip
    }
    EquipmentActions equipmentActions;


    [Header("EqupmentSlots")]
    public ItemData weaponSlot; //Слот для оружия



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
                if (weaponSlot == null)
                {
                    weaponSlot = _item; //запись оружия в слот
                    Instantiate(_item.prefab, GameManager.instance.playerController.rightHand.transform);//создание оружия в руке
                    GameManager.instance.playerController.weaponCollider = GameManager.instance.playerController.rightHand.transform.GetChild(0).GetComponent<BoxCollider>();//установка коллайдера оружия
                    GameManager.instance.playerController.weaponCollider.enabled = false;//отключение коллайдера оружия
                    GameManager.instance.GUIManager.AddEquip(_item);//перенос оружия в слот экипировки
                    GameManager.instance.playerController.playerInventory.InventoryAction(Inventory.InventoryActions.remove, _item);
                    Debug.Log(GameManager.instance.playerController.rightHand.transform.GetChild(0).GetComponent<BoxCollider>());
                }
                else
                {
                    if (weaponSlot.itemName == _item.itemName)
                    {
                        UpEqip(weaponSlot);
                    }
                    else
                    {
                        EquipmentAction(EquipmentActions.equip, _item);
                    }
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

    public void UpEqip (ItemData _item)
    {
        switch (_item.itemType)
        {
            case ItemData.ItemType.etc:
                break;

            case ItemData.ItemType.weapon:
                    GameManager.instance.playerController.playerInventory.InventoryAction(Inventory.InventoryActions.add, weaponSlot);
                    Destroy(GameManager.instance.playerController.rightHand.transform.GetChild(0).gameObject);//уничтожение оружия в руке
                    GameManager.instance.playerController.weaponCollider = null;//установка коллайдера в ноль
                    weaponSlot = null;
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
