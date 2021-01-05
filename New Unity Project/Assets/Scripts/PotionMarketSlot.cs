using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionMarketSlot : MonoBehaviour
{
    public Potion potion;

    public Image potionIcon;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI count;
    public Image materialIcon;
    public Inventory inven;

    public void View_Potionmarket_Slot()
    {
        potionIcon.sprite = potion.itemIcon;
        Name.text = potion.itemName;
        count.text = potion.price.ToString();
        materialIcon.sprite = DBmanager.instance.materialList[potion.price_material - 300].itemIcon;
    }

    public void Click()
    {
        
        Item useitem = DBmanager.instance.materialList[potion.price_material - 300];
        useitem.itemCount = potion.price;
        if (inven.useItem(useitem))
        {
            inven.GetItem(potion);
            Debug.Log("구매에 성공했습니다!");
            return;
        }
        Debug.Log("재료가 부족합니다.");

    }

}
