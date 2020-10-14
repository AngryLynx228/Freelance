using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataSlot : MonoBehaviour
{
    public bool equipped;
    public ItemData item;
    public GameObject text;
    public int count = 0;

    public void setData (ItemData _item, int _count, bool _eqipped)
    {
        if (_item != null)
        {
            item = _item;
            count = _count;
            equipped = _eqipped;
            text.GetComponent<Text>().text = _item.itemName;
        }
        //(count.ToString())
    }

    public void OnClicked ()
    {
        if (equipped)
        {
            GameManager.instance.playerController.playerEquipment.EquipmentAction(Equipment.EquipmentActions.upequip, item);
            GameManager.instance.playerController.playerInventory.InventoryAction(Inventory.InventoryActions.add, item);
        }
        else
        {
            GameManager.instance.playerController.playerEquipment.EquipmentAction(Equipment.EquipmentActions.equip, item);
        }


        if (count == 1)
        {
            if (equipped)
            {
                text.GetComponent<Text>().text = "";
                setData(null, 0, false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
