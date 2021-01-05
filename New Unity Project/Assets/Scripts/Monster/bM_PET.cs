using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bM_PET : LifeEntity
{
    private void Start()
    {
        is_Boss = true;

        this.HP = 90;
        this.CurrentHP = HP;
        this.AttackPower = 7;
        Item item = DBmanager.instance.materialList[5];
        dropitem.GetComponent<DropItem>().item = item;
        dropitem.GetComponent<SpriteRenderer>().sprite = item.itemIcon;

    }
}
