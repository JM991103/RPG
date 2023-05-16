using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button xButton;

    public void AddItem(Item newitem)
    {
        item = newitem;
        icon.sprite = item.icon;
        icon.enabled = true;
        xButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        xButton.interactable = false;
    }

    public void onXButtonClick()
    {
        Inventory.instance.Remove(item);
    }

    public void OnItemButtonClick()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
