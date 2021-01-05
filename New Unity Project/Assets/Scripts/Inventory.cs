using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Inventory : MonoBehaviour
{
    public static Inventory inveninstance;
    public List<Item> OwnItem = new List<Item>();
    private InventorySlot[] slots;

    public TextMeshProUGUI hpPotion;
    public TextMeshProUGUI atkPotion;

    private void Awake()
    {
        inveninstance = this;
        slots = this.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < DBmanager.instance.itemList.Count; i++)
        {
            GetItem(DBmanager.instance.itemList[i]);
        }
    }
   
    private void Start()
    {
        ViewInventory();
    }

    public void GetItem(Item item)
    {
        for(int i = 0; i < OwnItem.Count; i++)
        {
            if(OwnItem[i].itemID == item.itemID)
            {
                OwnItem[i].itemCount += item.itemCount;
                return;
            }
        }
        OwnItem.Add(item);
    }

    public bool useItem(Item item)
    {
        for (int i = 0; i < OwnItem.Count; i++)
        {
            if (OwnItem[i].itemID == item.itemID)
            {
                if (OwnItem[i].itemCount < item.itemCount)
                {
                    return false;
                }
                OwnItem[i].itemCount -= item.itemCount;
                if(OwnItem[i].itemCount == 0)
                {
                    OwnItem.RemoveAt(i);
                }
                return true;
            }
        }
        return false;

    }



    public void ViewInventory()
    {
        Debug.Log(OwnItem.Count);
        for(int i = 0; i < OwnItem.Count; i++)
        {
            try
            {
                slots[i].insertItem(OwnItem[i]);
                slots[i].ChagneSlot_Content();
            }
            catch(NullReferenceException ie)
            {
                Debug.Log(ie);
            }
            
        }
    }
    public void potionCountUpdate(int num)
    {
        Item potion;
        if (num == 1)
        {
            try
            {
                potion = DBmanager.instance.potionList[0];
                for (int i = 0; i < OwnItem.Count; i++)
                {
                    if (OwnItem[i].itemID == potion.itemID)
                    {
                        hpPotion.text = OwnItem[i].itemCount.ToString();
                    }
                }
            }
            catch(NullReferenceException ie)
            {
                Debug.Log(ie);
                hpPotion.text = "0";
            }
            
        }
       
        if (num == 2)
        {
            try
            {
                potion = DBmanager.instance.potionList[1];
                for (int i = 0; i < OwnItem.Count; i++)
                {
                    if (OwnItem[i].itemID == potion.itemID)
                    {
                        atkPotion.text = OwnItem[i].itemCount.ToString();
                    }
                }
            }
            catch(NullReferenceException ie)
            {
                Debug.Log(ie);
                atkPotion.text = "0";
            }
           
        }


    }
}
