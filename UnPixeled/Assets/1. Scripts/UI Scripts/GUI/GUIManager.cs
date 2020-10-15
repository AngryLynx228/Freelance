using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    // Variables //________________________________________________________________________________________________________________________________________________________________
    [SerializeField] public Slider healthBar;
    [SerializeField] public Slider energyBar;
    [SerializeField] public Slider expirienceBar;
    [SerializeField] public GameObject itemSlotPrefab;
    [SerializeField] public GameObject inventoryHolder;
    [SerializeField] public GameObject InventoryPannell;
    [SerializeField] public Sprite defaultItemIcon;
    bool InventoryEnabled = false;
    public List<GameObject> inventoryHolerItems;

    [Header("EquipmentSlots")]
    public GameObject weaponSlot;



    public void Update()
    {
        if (GameManager.instance.playerController.enableInput)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                InventoryPannell.SetActive(InventoryEnabled);
                InventoryEnabled = !InventoryEnabled;
            }
        }
    }


    // Functions //____________________________________________________________________________________________________________________________________________________________________________
    public void HealthBar (float ammount)
    {
        healthBar.value = ammount;
    }

    public void EnergyBar(float ammount)
    {
        energyBar.value = ammount;
    }

    public void ExpirienceBar(float ammount)
    {
        expirienceBar.value = ammount;
    }


    // Inventory and equipment
    public void AddSlot (ItemData _item, int _count)
    {
        GameObject newItemDataSlot = Instantiate(itemSlotPrefab, inventoryHolder.transform);
        newItemDataSlot.GetComponent<ItemDataSlot>().setData(_item, _count, false);
        inventoryHolerItems.Add(newItemDataSlot);
    }

    public void AddCount (ItemData _item, int _count)
    {
        for (int i = 0; i < inventoryHolerItems.Count; i++)
        {
            if (inventoryHolerItems[i].GetComponent<ItemDataSlot>().item.itemName == _item.itemName)
            {
                inventoryHolerItems[i].GetComponent<ItemDataSlot>().setData(_item, _count, false);
            }
        }
    }

    public void RemoveCount (ItemData _item, int _count)
    {
        for (int i = 0; i < inventoryHolerItems.Count; i++)
        {
            if (inventoryHolerItems[i].GetComponent<ItemDataSlot>().item.itemName == _item.itemName)
            {
                inventoryHolerItems[i].GetComponent<ItemDataSlot>().count -= _count;
            }
        }
    }

    public void AddEquip (ItemData _item)
    {
        switch (_item.itemType)
        {
            case ItemData.ItemType.etc:
                break;

            case ItemData.ItemType.weapon:
                weaponSlot.GetComponent<ItemDataSlot>().setData(_item, _item.count, true);
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
