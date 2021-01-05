using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMakeUI : MonoBehaviour
{
    public GameObject ItemList;
    public MakeItemSlot[] makeItemSlots;
    public GameObject NeedItemList;
    public MakeItemSlot[] NeedItemSlots;
    public Inventory inven;
    List<Recipe> recipes = new List<Recipe>();

    private AudioSource audioSource;
    public AudioClip s_makeItem;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        makeItemSlots = ItemList.GetComponentsInChildren<MakeItemSlot>();
        NeedItemSlots = NeedItemList.GetComponentsInChildren<MakeItemSlot>();
        recipes = DBmanager.instance.itemRecipe;
        View_Makeable_items();
    }
    public void View_Makeable_items()
    {
        
        for(int i = 0; i < recipes.Count; i++)
        {
            makeItemSlots[i].ChangeImage(recipes[i].ItemID);
        }
    }
    public void View_Need_Items(int id)
    {
        Debug.Log("View Need Items"+id);
        int j = id - 100;
        Debug.Log(recipes[j].ItemID +","+recipes[j].NeedItems[0].itemID+","+recipes[j].NeedItems[1].itemID);
        
        for(int i = 0; i < recipes[j].NeedItemsCount; i++)
        {
            NeedItemSlots[i].ChageNeedItem(recipes[j].NeedItems[i]);
        }
    }

    public bool MakeItem(MakeItemSlot makeitem)
    {
        
        Debug.Log("maekItem함수 진입!");
        int index = makeitem.MakeItem.itemID - 100;

        for(int i = 0; i < recipes[index].NeedItemsCount; i++)
        {
            Item needitem = recipes[index].NeedItems[i];

            if (!inven.useItem(needitem))
            {
                Debug.Log("재료부족");
                return false;
            }
        }
        audioSource.clip = s_makeItem;
        audioSource.Play();
        Debug.Log("아이템 제작 성공");
        inven.GetItem(makeitem.MakeItem);
        return true;

    }
    public void ClearSlots()
    {
        Debug.Log("clearSlots");
        for(int i = 0; i < makeItemSlots.Length; i++)
        {
            makeItemSlots[i].ClearSlots();
        }
    }
}
