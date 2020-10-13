using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public ItemData weapon1;

    public enum EquipmentActions
    {
        equipWeapon,
        equipArmor
    }
    public EquipmentActions equpmentActions;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            weapon1 = GetComponent<Inventory>().inventory[0];
            EquipmentAction(EquipmentActions.equipWeapon, weapon1);
        }
    }

    public void EquipmentAction(EquipmentActions action, ItemData item)
    {
        switch (action)
        {
            case EquipmentActions.equipWeapon:
                EquipWeapon(item);
                break;
            case EquipmentActions.equipArmor:
                break;
            default:
                break;
        }
    }

    public void EquipWeapon (ItemData item)
    {
        if (item != null)
        {
            GameManager.instance.playerController.weapon = Instantiate(item.prefab, GameManager.instance.playerController.rightHand.transform);
            GameManager.instance.playerController.InitWeapon();
        }
    }
}
