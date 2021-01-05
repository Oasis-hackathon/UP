using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bM_PET : LifeEntity
{
    public Item DropItem;
    private void Start()
    {
        DropItem = DBmanager.instance.materialList[5];
        this.HP = 40;
        this.CurrentHP = HP;
        this.AttackPower = 6;
    }
    public override void Dead()
    {
        base.Dead();
        ItemDrop(DropItem);
    }
}
