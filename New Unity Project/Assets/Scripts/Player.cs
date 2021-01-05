using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : LifeEntity
{
    public Weapon equip;
    public List<Item> apply;
    private int def;
    private int baseAttackpower;

    public Potion potion1;
    public Potion potion2;
    public int Def
    {
        get { return def; }
    }
    // 착용한 무기
    // 사용중인 물약
    // 
    private void Start()
    {
        this.HP = 100;
        this.CurrentHP = HP;
        this.AttackPower = baseAttackpower;
        this.def = 0;
    }
    private void Update()
    {
        
    }

    public override void be_attacked(int _attackPower)
    {
        base.be_attacked(_attackPower);
        // 피격시 애니메이션 실행
    }

    public override void Dead()
    {
        is_Dead = true;
        // 죽음 애니메이션 실행
        // 죽었을시 뭐 살아나는 방법
    }

    public void recovery(Potion potion)
    {
        if (CurrentHP == HP )
        {
            return;
        }
        if(potion.potion_Type == 0)
        {
            CurrentHP += potion.potion_Volume;
        }
        else
        {
            return;
        }
        Inventory.inveninstance.useItem(potion);
    }

    public void Usepotion(Potion potion)
    {
        if (potion.potion_Type == 0 )
        {
            recovery(potion);
        }
        else
        {
            enhance(potion);
        }
    }

    public void enhance(Potion potion)
    {
        if (apply.Contains(potion))
        {
            return;
        }

        if(potion.potion_Type == 1)
        {
            this.def += potion.potion_Volume;
        }
        else if(potion.potion_Type == 2)
        {
            this.AttackPower += potion.potion_Volume;
        }
        else
        {
            return;
        }
        Inventory.inveninstance.useItem(potion);
    }

    public void fitIn(Weapon weapon)
    {
        equip = weapon;
        AttackPower += equip.weapon_AttackPower;
    }

    IEnumerator potiontime(Potion potion)
    {
        yield return new WaitForSeconds(potion.potion_Time);
        if (potion.potion_Type == 1)
        {
            this.def -= potion.potion_Volume;
        }
        if(potion.potion_Type == 2)
        {
            this.AttackPower -= potion.potion_Volume;
        }
    }
}
