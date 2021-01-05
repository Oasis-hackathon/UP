using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : LifeEntity
{
    public Weapon equip;
    public List<Item> apply;
    public GameObject deadMassage;

    private int def;
    private int baseAttackpower = 5;
    private StatusUI status;
    public int Def
    {
        get { return def; }
    }
    // 착용한 무기
    // 사용중인 물약
    private void Awake()
    {
        
    }
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
        deadMassage.SetActive(true);
        // 죽음 애니메이션 실행
        // 죽었을시 뭐 살아나는 방법
    }

    public void recovery()
    {
        Potion potion = DBmanager.instance.potionList[0];
        if (Inventory.inveninstance.useItem(potion))
        {
            if (CurrentHP == HP)
            {
                return;
            }
            CurrentHP += potion.potion_Volume;
        }
        else
        {
            return;
        }

        
    }

    public void enhance()
    {
        Potion potion = DBmanager.instance.potionList[1];
        if (apply.Contains(potion))
        {
            return;
        }
       
        if (Inventory.inveninstance.useItem(potion))
        {
            this.AttackPower += potion.potion_Volume;
            apply.Add(potion);
            StartCoroutine(potiontime(potion));
        }
        else
        {
            return;
        }
    }

    public void fitIn(Weapon weapon)
    {
        if(equip != null)
        {
            AttackPower -= equip.weapon_AttackPower;
        }
        equip = weapon;
        AttackPower += equip.weapon_AttackPower;
        status = FindObjectOfType<StatusUI>();
        status.View_Status();
    }
    public void Resurrection()
    {
        is_Dead = false;
    }
    IEnumerator potiontime(Potion potion)
    {
        yield return new WaitForSeconds(potion.potion_Time);
        apply.RemoveAt(0);
        this.AttackPower -= potion.potion_Volume;

    }

}
