using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEntity : MonoBehaviour
{
    private int hp;

    private int currentHP;
    private int currentMP;
    private int attackPower;
    private int defensivePower;
    protected bool is_Dead;
    protected bool is_Dash;

    public int AttackPower
    {
        get { return attackPower; }
        set {
            if (value > 0)
            {
                attackPower = value;
            }
            }
    }
    public int HP {
        get { return hp; }
        set
        {
            if (value > 0)
            {
                hp = value;
            }
        }
    }

    public int CurrentHP
    {
        get { return currentHP; }
        set
        {
            if (value > hp)
            {
                currentHP = hp;
            }
            currentHP = value;
        }
    }




    public int DefensivePower
    {
        get { return defensivePower; }
        set
        {
            if(value >= 0)
            {
                defensivePower = value;
            }
        }
    }
    public bool Is_Dead
    {
        get { return is_Dead; }
    }
    public bool Is_Dash
    {
        get { return is_Dash; }
        set
        {
            is_Dash = value;
        }
    }

    private void Start()
    {
        is_Dead = false;
        is_Dash = false;
    }

    public virtual void be_attacked(int _attackPower)
    {
        if (is_Dash)
        {
            return;
        }
        this.currentHP -= _attackPower;
        if (this.currentHP <= 0)
        {
            Dead();
        }
    }
    public virtual void Dead()
    {
        
        Debug.Log("DEAD");
        is_Dead = true;
    }
    public void ItemDrop(Item item)
    {
        Instantiate(item.itemIcon, this.transform);
        this.transform.position = new Vector2(-100, 50);

    }


}
