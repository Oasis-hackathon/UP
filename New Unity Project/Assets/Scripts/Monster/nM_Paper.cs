using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nM_Paper : LifeEntity
{
    private void Start()
    {
        this.HP = 30;
        this.CurrentHP = HP;
        this.AttackPower = 5;
        Item item = DBmanager.instance.materialList[0];
        dropitem.GetComponent<DropItem>().item = item;
        dropitem.GetComponent<SpriteRenderer>().sprite = item.itemIcon;
    }
    

}
