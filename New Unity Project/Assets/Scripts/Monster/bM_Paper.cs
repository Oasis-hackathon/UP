using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bM_Paper : LifeEntity
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
        Debug.Log("DEAD");
        this.transform.position = new Vector2(70, 25);
        is_Dead = true;
        //temDrop(DropItemID);
    }
}