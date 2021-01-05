using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inveninstance;
    public List<Item> OwnItem = new List<Item>();
    private InventorySlot[] slots;

    private void Awake()
    {
        inveninstance = this;
    }
    private void Start()
    {
        slots = this.GetComponentsInChildren<InventorySlot>();
        Debug.Log(DBmanager.instance.itemList[5]);
        Item item = DBmanager.instance.itemList[5];
        Debug.Log(item);
        GetItem(item);
        Debug.Log("호 영 조 아");
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
        Debug.Log("useItem함수 진입");
        for (int i = 0; i < OwnItem.Count; i++)
        {
            if (OwnItem[i].itemID == item.itemID)
            {
                if (OwnItem[i].itemCount < item.itemCount)
                {
                    return false;
                }
                OwnItem[i].itemCount -= item.itemCount;
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
}
