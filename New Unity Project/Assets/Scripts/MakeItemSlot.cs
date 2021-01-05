using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MakeItemSlot : MonoBehaviour
{
    public Image SlotIcon;
    public Item MakeItem;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Count;

    public ItemMakeUI itemmakeUI;

    public void IconClick()
    {
        try
        {
            itemmakeUI.View_Need_Items(MakeItem.itemID);
            UI.UIinstance.SelectedMake = this;
        }
        catch(ArgumentOutOfRangeException ie)
        {
            Debug.Log(ie);
            return;
        }
        
        
    }
    public void ChangeImage(int id)
    {
        MakeItem = DBmanager.instance.weaponList[id - 100];
        SlotIcon.sprite = MakeItem.itemIcon;
    }
    public void ChageNeedItem(Item item)
    {
        MakeItem = item;
        SlotIcon.sprite = item.itemIcon;
        Name.text = item.itemName;
        Count.text = item.itemCount.ToString();
    }
    public void ClearSlots()
    {
        Name.text = "";
        Count.text = "";
    }
}
