using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMarket : MonoBehaviour
{
    public GameObject potionmarket;
    public PotionMarketSlot[] marketSlots;

    private void Start()
    {
        marketSlots = potionmarket.GetComponentsInChildren<PotionMarketSlot>();
        for(int i = 0; i < DBmanager.instance.potionList.Count; i++)
        {
            marketSlots[i].potion = DBmanager.instance.potionList[i];
            marketSlots[i].View_Potionmarket_Slot();
        }
    }



}
