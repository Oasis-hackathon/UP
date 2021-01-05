using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using UnityEngine;

public class DBmanager : MonoBehaviour
{
    static public DBmanager instance;

    //public Dictionary<string, float> vardic;

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();
    public List<Weapon> weaponList = new List<Weapon>();
    public List<Potion> potionList = new List<Potion>();
    public List<Material> materialList = new List<Material>();

    public List<Recipe> itemRecipe = new List<Recipe>();

    public List<Stage> stageList = new List<Stage>();

    public List<string> PotionDialogue = new List<string>();
    public List<string> PlayerDialogue = new List<string>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        weaponList.Add(new Weapon(100, "종이 칼", "박스 몬스터들의 잔해를 재활용하여 만든 칼 입니다.", Item.ItemType.Weapon, 5, 1, false));
        weaponList.Add(new Weapon(101, "비닐 칼", "비닐 몬스터들의 잔해를 재활용하여 만든 칼 입니다.", Item.ItemType.Weapon, 7, 2, false));
        weaponList.Add(new Weapon(102, "투명 페트 둔기", "투명 페트 몬스터들의 잔해를 재활용하여 만든 둔기 입니다.", Item.ItemType.Weapon, 12, 3, true));
        weaponList.Add(new Weapon(103, "플라스틱 칼", "플라스틱 몬스터들의 잔해를 재활용하여 만든 칼 입니다.", Item.ItemType.Weapon, 13, 4, false));
        weaponList.Add(new Weapon(104, "캔 둔기", "캔 몬스터들의 잔해를 재활용하여 만든 둔기 입니다.", Item.ItemType.Weapon, 17, 5, true));

        potionList.Add(new Potion(200, "hp물약1", "5회복", Item.ItemType.Potion, 0, 5, 0, 2, 300));
        potionList.Add(new Potion(201, "hp물약2", "6회복", Item.ItemType.Potion, 0, 6, 0, 2, 302));
        potionList.Add(new Potion(202, "hp물약3", "7회복", Item.ItemType.Potion, 0, 7, 0,2,304));
        potionList.Add(new Potion(203, "hp물약4", "8회복", Item.ItemType.Potion, 0, 8, 0,2,306));
        potionList.Add(new Potion(204, "hp물약5", "9회복", Item.ItemType.Potion, 0, 9, 0,2,308));
        potionList.Add(new Potion(205, "mp물약1", "5회복", Item.ItemType.Potion, 1, 5, 0,2,300));
        potionList.Add(new Potion(206, "mp물약2", "6회복", Item.ItemType.Potion, 1, 6, 0,2,302));
        potionList.Add(new Potion(207, "mp물약3", "7회복", Item.ItemType.Potion, 1, 7, 0,2,304));
        potionList.Add(new Potion(208, "mp물약4", "8회복", Item.ItemType.Potion, 1, 8, 0,2,306));
        potionList.Add(new Potion(209, "mp물약5", "9회복", Item.ItemType.Potion, 1, 9, 0,2,308));
        potionList.Add(new Potion(210, "def물약1", "1증가", Item.ItemType.Potion, 2, 1, 120,3,300));
        potionList.Add(new Potion(211, "def물약2", "2증가", Item.ItemType.Potion, 2, 2, 120,3,302));
        potionList.Add(new Potion(212, "def물약3", "3증가", Item.ItemType.Potion, 2, 3, 120,3,304));
        potionList.Add(new Potion(213, "def물약4", "4증가", Item.ItemType.Potion, 2, 4, 120,3,306));
        potionList.Add(new Potion(214, "def물약5", "5증가", Item.ItemType.Potion, 3, 5, 120,3,308));
        potionList.Add(new Potion(215, "atk물약1", "1증가", Item.ItemType.Potion, 3, 1, 120,3,300));
        potionList.Add(new Potion(216, "atk물약2", "2증가", Item.ItemType.Potion, 3, 2, 120,3,302));
        potionList.Add(new Potion(217, "atk물약3", "3증가", Item.ItemType.Potion, 3, 3, 120,3,304));
        potionList.Add(new Potion(218, "atk물약4", "4증가", Item.ItemType.Potion, 3, 4, 120,3,306));
        potionList.Add(new Potion(219, "atk물약5", "5증가", Item.ItemType.Potion, 3, 5, 120,3,308));

        materialList.Add(new Material(300, "종이_n", "종이 몬스터의 잔해입니다.", Item.ItemType.Material, 0));
        materialList.Add(new Material(301, "종이_b", "종이 몬스터의 잔해입니다.", Item.ItemType.Material, 0));
        materialList.Add(new Material(302, "비닐_n", "비닐 몬스터의 잔해입니다.", Item.ItemType.Material, 1));
        materialList.Add(new Material(303, "비닐_b", "비닐 몬스터의 잔해입니다.", Item.ItemType.Material, 1));
        materialList.Add(new Material(304, "투명페트_n", "투명페트 몬스터의 잔해입니다.", Item.ItemType.Material, 2));
        materialList.Add(new Material(305, "투명페트_ b", "투명페트 몬스터의 잔해입니다.", Item.ItemType.Material, 2));
        materialList.Add(new Material(306, "플라스틱_n", "플라스틱 몬스터의 잔해입니다.", Item.ItemType.Material, 3));
        materialList.Add(new Material(307, "플라스틱_b", "플라스틱 몬스터의 잔해입니다.", Item.ItemType.Material, 3));
        materialList.Add(new Material(308, "캔_n", "캔 몬스터의 잔해입니다.", Item.ItemType.Material, 4));
        materialList.Add(new Material(309, "캔_b", "캔 몬스터의 잔해입니다.", Item.ItemType.Material, 4));

        //int num = 5;
        Item item1 = new Material(300, "종이_n", "종이 몬스터의 잔해입니다.", Item.ItemType.Material, 0);
        Item item2 = new Material(301, "종이_b", "종이 몬스터의 잔해입니다.", Item.ItemType.Material, 0);
        item1.itemCount = 5;

        itemRecipe.Add(new Recipe(100, 2, item1,item2));

        item1 = new Material(302, "비닐_n", "비닐 몬스터의 잔해입니다.", Item.ItemType.Material, 1);
        item2 = new Material(303, "비닐_b", "비닐 몬스터의 잔해입니다.", Item.ItemType.Material, 1);
        item1.itemCount = 5;
        itemRecipe.Add(new Recipe(101, 2, item1, item2));

        item1 = new Material(304, "투명페트_n", "투명페트 몬스터의 잔해입니다.", Item.ItemType.Material, 2);
        item2 = new Material(305, "투명페트_ b", "투명페트 몬스터의 잔해입니다.", Item.ItemType.Material, 2);
        item1.itemCount = 5;

        itemRecipe.Add(new Recipe(102, 2, item1, item2));

        item1 = new Material(306, "플라스틱_n", "플라스틱 몬스터의 잔해입니다.", Item.ItemType.Material, 3);
        item2 = new Material(307, "플라스틱_b", "플라스틱 몬스터의 잔해입니다.", Item.ItemType.Material, 3);
        item1.itemCount = 5;

        itemRecipe.Add(new Recipe(103, 2, item1, item2));

        item1 = new Material(308, "캔_n", "캔 몬스터의 잔해입니다.", Item.ItemType.Material, 4);
        item2 = new Material(309, "캔_b", "캔 몬스터의 잔해입니다.", Item.ItemType.Material, 4);
        item1.itemCount = 5;
        itemRecipe.Add(new Recipe(104, 2, item1, item2));

        itemList.Add(new Weapon(100, "종이 칼", "박스 몬스터들의 잔해를 재활용하여 만든 칼 입니다.", Item.ItemType.Weapon, 5, 1, false));
        itemList.Add(new Weapon(101, "비닐 칼", "비닐 몬스터들의 잔해를 재활용하여 만든 칼 입니다.", Item.ItemType.Weapon, 7, 2, false));
        itemList.Add(new Weapon(102, "투명 페트 둔기", "투명 페트 몬스터들의 잔해를 재활용하여 만든 둔기 입니다.", Item.ItemType.Weapon, 12, 3, true));
        itemList.Add(new Weapon(103, "플라스틱 칼", "플라스틱 몬스터들의 잔해를 재활용하여 만든 칼 입니다.", Item.ItemType.Weapon, 13, 4, false));
        itemList.Add(new Weapon(104, "캔 둔기", "캔 몬스터들의 잔해를 재활용하여 만든 둔기 입니다.", Item.ItemType.Weapon, 17, 5, true));
        itemList.Add(new Potion(200, "hp물약1", "5회복", Item.ItemType.Potion, 0, 5, 0, 2, 300));
        itemList.Add(new Potion(201, "hp물약2", "6회복", Item.ItemType.Potion, 0, 6, 0, 2, 302));
        itemList.Add(new Potion(202, "hp물약3", "7회복", Item.ItemType.Potion, 0, 7, 0, 2, 304));
        itemList.Add(new Potion(203, "hp물약4", "8회복", Item.ItemType.Potion, 0, 8, 0, 2, 306));
        itemList.Add(new Potion(204, "hp물약5", "9회복", Item.ItemType.Potion, 0, 9, 0, 2, 308));
        itemList.Add(new Potion(210, "def물약1", "1증가", Item.ItemType.Potion, 1, 1, 120, 3, 300));
        itemList.Add(new Potion(211, "def물약2", "2증가", Item.ItemType.Potion, 1, 2, 120, 3, 302));
        itemList.Add(new Potion(212, "def물약3", "3증가", Item.ItemType.Potion, 1, 3, 120, 3, 304));
        itemList.Add(new Potion(213, "def물약4", "4증가", Item.ItemType.Potion, 1, 4, 120, 3, 306));
        itemList.Add(new Potion(214, "def물약5", "5증가", Item.ItemType.Potion, 1, 5, 120, 3, 308));
        itemList.Add(new Potion(215, "atk물약1", "1증가", Item.ItemType.Potion, 2, 1, 120, 3, 300));
        itemList.Add(new Potion(216, "atk물약2", "2증가", Item.ItemType.Potion, 2, 2, 120, 3, 302));
        itemList.Add(new Potion(217, "atk물약3", "3증가", Item.ItemType.Potion, 2, 3, 120, 3, 304));
        itemList.Add(new Potion(218, "atk물약4", "4증가", Item.ItemType.Potion, 2, 4, 120, 3, 306));
        itemList.Add(new Potion(219, "atk물약5", "5증가", Item.ItemType.Potion, 2, 5, 120, 3, 308));
        itemList.Add(new Material(300, "종이_n", "종이 몬스터의 잔해입니다.", Item.ItemType.Material, 0));
        itemList.Add(new Material(301, "종이_b", "종이 몬스터의 잔해입니다.", Item.ItemType.Material, 0));
        itemList.Add(new Material(302, "비닐_n", "비닐 몬스터의 잔해입니다.", Item.ItemType.Material, 1));
        itemList.Add(new Material(303, "비닐_b", "비닐 몬스터의 잔해입니다.", Item.ItemType.Material, 1));
        itemList.Add(new Material(304, "투명페트_n", "투명페트 몬스터의 잔해입니다.", Item.ItemType.Material, 2));
        itemList.Add(new Material(305, "투명페트_ b", "투명페트 몬스터의 잔해입니다.", Item.ItemType.Material, 2));
        itemList.Add(new Material(306, "플라스틱_n", "플라스틱 몬스터의 잔해입니다.", Item.ItemType.Material, 3));
        itemList.Add(new Material(307, "플라스틱_b", "플라스틱 몬스터의 잔해입니다.", Item.ItemType.Material, 3));
        itemList.Add(new Material(308, "캔_n", "캔 몬스터의 잔해입니다.", Item.ItemType.Material, 4));
        itemList.Add(new Material(309, "캔_b", "캔 몬스터의 잔해입니다.", Item.ItemType.Material, 4));
        
        stageList.Add(new Stage("Lobby", "로비.", 0));
        stageList.Add(new Stage("Stage1", "종이", 1));
        stageList.Add(new Stage("Stage2", "비닐", 2));
        stageList.Add(new Stage("Stage3", "투명페트", 3));
        stageList.Add(new Stage("Stage4", "플라스틱", 4));
        stageList.Add(new Stage("Stage5", "캔", 5));


    }



}
