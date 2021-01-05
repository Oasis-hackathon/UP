using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySlot : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI CountText;
    public GameObject PopUPDec;
    public GameObject Button;
    public TextMeshProUGUI ButtonText;
    public Player playerAction;
    public GameObject PotionButton1;
    public GameObject PotionButton2;


    public Item item;   
    /*
    public Item slotItem
    {
        get { return item; }
        set
        {
            item = value;
        }
    }*/
   
    void Start()
    {
    }

    void Update()
    {
        
    }
    public void insertItem(Item _item)
    {
        
        item = _item;
    }
    public void ChagneSlot_Content()
    {
        Icon.sprite = item.itemIcon;
        CountText.text = item.itemCount.ToString();
    }
    public void ViewSlot_Content()
    {
        Debug.Log(item.itemName);
        TextMeshProUGUI text = PopUPDec.GetComponentInChildren<TextMeshProUGUI>();
        text.text = item.itemName; /*+ "\t ("+slotItem.itemCount+ ")"+"\n"
            + slotItem.itemDesctription + "\n" ;*/
        UI.UIinstance.SelectedSlot = this;

        
        if (this.item.itemType == Item.ItemType.Weapon)
        {
            Button.SetActive(true);
            ButtonText.text = "장착";
        }
        else
        {
            Button.SetActive(false);
        }
    }
    public void Use_Button()
    {
        if (this.item.itemType == Item.ItemType.Weapon)
        {
            int index = item.itemID - 100;
            Debug.Log(index);
            Weapon weapon = DBmanager.instance.weaponList[index];
            playerAction.fitIn(weapon); 

        }
        
    }

    

}
