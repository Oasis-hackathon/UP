
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    int attackPower;
    bool is_Attacking;
    BoxCollider2D col;

    private void Start()
    {
        attackPower = 10;//this.GetComponentInParent<LifeEntity>().AttackPower;
        col = this.GetComponent<BoxCollider2D>();
    }
    public void playerAttackMotion()
    {
        if (is_Attacking)
        {
            return;
        }
        is_Attacking = true;
        col.enabled = true;
        col.isTrigger = true;
        Invoke("Attacking", 0.5f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Monster" || other.tag == "Player")
        {
            Debug.Log(other.name + "감지시작!");

            other.GetComponent<LifeEntity>().be_attacked(attackPower);
            if(this.tag == "Weapon")
            {
                

            }
        }

    }
    void Attacking()
    {
        is_Attacking = false;
        col.enabled = false;
        col.isTrigger = false;
    }
}
