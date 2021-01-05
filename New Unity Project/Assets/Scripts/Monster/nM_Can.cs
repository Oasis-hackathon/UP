using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nM_Can :   LifeEntity
{
    public int DropItemID;
    private void Start()
    {
        DropItemID = 300;
        this.HP = 30;
        this.CurrentHP = HP;
        this.AttackPower = 5;
    }
    public override void Dead()
    {
        base.Dead();
        ItemDrop(DropItemID);
    }
}
