using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nM_Paper : LifeEntity
{
    public Item DropItem;
    private void Start()
    {
        DropItem = DBmanager.instance.materialList[0];
        this.HP = 30;
        this.CurrentHP = HP;
        this.AttackPower = 5;
    }
    public override void Dead()
    {
        base.Dead();
        ItemDrop(DropItem);
    }
}
