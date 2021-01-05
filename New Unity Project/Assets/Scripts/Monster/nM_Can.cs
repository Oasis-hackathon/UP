using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nM_Can :   LifeEntity
{
    private void Start()
    {
        this.HP = 90;
        this.CurrentHP = HP;
        this.AttackPower = 5;
        Item item = DBmanager.instance.materialList[8];
        dropitem.GetComponent<DropItem>().item = item;
        dropitem.GetComponent<SpriteRenderer>().sprite = item.itemIcon;
    }
}
