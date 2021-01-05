using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bM_Vinyl : LifeEntity
{
    public Item DropItem;
    private void Start()
    {
        DropItem = DBmanager.instance.materialList[3];
        this.HP = 110;
        this.CurrentHP = HP;
        this.AttackPower = 10;
    }
    public override void Dead()
    {
        base.Dead();
        ItemDrop(DropItem);
    }
}
