using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ItemDataSlot : MonoBehaviour
{
    public bool equipmentSlot;
    public bool inInventory;
    public ItemData item;
    public GameObject text;
    public int count = 0;



    public void setData (ItemData _item, int _count, bool _inInventory)
    {
        if (_item != null)
        {
            item = _item;
            count = _count;
            GetComponent<Image>().sprite = _item.itemIcon;
            text.GetComponent<Text>().text = _item.itemName;        //(count.ToString())
        }
        else
        {
            GetComponent<Image>().sprite = GameManager.instance.GUIManager.defaultItemIcon;
        }
    }

    public void OnClicked ()
    {
        GameManager.instance.playerController.playerEquipment.EquipmentAction(Equipment.EquipmentActions.equip, item);


        if (equipmentSlot)
        {
            text.GetComponent<Text>().text = "";
            setData(null, 0, false);
        }
        else
        {
            if (count > 1)
            {

            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
