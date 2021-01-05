using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public Player player;
    public Image equipWeapon;
    public Sprite normalimage;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI defText;


    //private Player playerscript;
    public void Start()
    {
        //playerscript = player.GetComponent<Player>();
    }
    public void View_Status()
    {
        try
        {
            equipWeapon.sprite = player.equip.itemIcon;
        }
        catch(NullReferenceException ie)
        {
            Debug.Log(ie);
        }
        
        hpText.text = player.HP.ToString();

        atkText.text = player.AttackPower.ToString();
        defText.text = player.Def.ToString();

    }

}
