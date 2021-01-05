using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bM_Paper : LifeEntity
{

    private void Start()
    {
        is_Boss = true;
        
        this.HP = 60;
        this.CurrentHP = HP;
        this.AttackPower = 7;
        Item item = DBmanager.instance.materialList[1];
        dropitem.GetComponent<DropItem>().item = item;
        dropitem.GetComponent<SpriteRenderer>().sprite = item.itemIcon;

    }

}