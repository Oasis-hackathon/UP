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

    public bool tutorial_Ing;
    public bool tutorial_Fin;
    public int tutorial_Step;

    public List<Item> itemList = new List<Item>();
    public List<Weapon> weaponList = new List<Weapon>();
    public List<Potion> potionList = new List<Potion>();
    public List<Material> materialList = new List<Material>();

    public List<Recipe> itemRecipe = new List<Recipe>();

    public List<Stage> stageList = new List<Stage>();

    public List<string> PotionDialogue = new List<string>();
    public List<string> PlayerDialogue = new List<string>();

    
    public List<int[]> stageposition = new List<int[]>();
    public List<int[]> stageBosspositionList = new List<int[]>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        stageposition.Add(new int[] { -50, 20, -17, 0 });
        stageposition.Add(new int[] { -50, -7, -17, 7 });
        stageBosspositionList.Add(new int[]{ -40,10});
        stageBosspositionList.Add(new int[] { -11, -12 });

        weaponList.Add(new Weapon(100, "종이 칼", "박스 몬스터들의 잔해를 재활용하여 만든 칼 입니다.", Item.ItemType.Weapon, 5, 1, false));
        weaponList.Add(new Weapon(101, "비닐 칼", "비닐 몬스터들의 잔해를 재활용하여 만든 칼 입니다.", Item.ItemType.Weapon, 7, 2, false));
        weaponList.Add(new Weapon(102, "투명 페트 둔기", "투명 페트 몬스터들의 잔해를 재활용하여 만든 둔기 입니다.", Item.ItemType.Weapon, 12, 3, true));
        weaponList.Add(new Weapon(103, "플라스틱 칼", "플라스틱 몬스터들의 잔해를 재활용하여 만든 칼 입니다.", Item.ItemType.Weapon, 13, 4, false));
        weaponList.Add(new Weapon(104, "캔 둔기", "캔 몬스터들의 잔해를 재활용하여 만든 둔기 입니다.", Item.ItemType.Weapon, 17, 5, true));

        potionList.Add(new Potion(200, "hp물약", "5회복", Item.ItemType.Potion, 0, 5, 0, 2, 300));
        potionList.Add(new Potion(201, "atk물약1", "1증가", Item.ItemType.Potion, 2, 1, 120, 3, 300));

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
        itemList.Add(new Potion(201, "atk물약1", "1증가", Item.ItemType.Potion, 2, 1, 120, 3, 300));

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
