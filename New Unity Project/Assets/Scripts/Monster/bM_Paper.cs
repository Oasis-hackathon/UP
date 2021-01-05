using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bM_Paper : LifeEntity
{
    public Item DropItem;
    private void Start()
    {
        DropItem = DBmanager.instance.materialList[1];
        this.HP = 100;
        this.CurrentHP = HP;
        this.AttackPower = 7;
    }
    public override void Dead()
    {
        base.Dead();
        ItemDrop(DropItem);
    }
}