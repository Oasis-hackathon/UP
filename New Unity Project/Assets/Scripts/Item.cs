
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemID;
    public string itemName;
    public string itemDesctription;
    public int itemCount;
    public Sprite itemIcon;
    public ItemType itemType;
    public enum ItemType 
    { Potion,
    Weapon,
    Material}

    public Item(int _itemID, string _itemName, string _itemDec, ItemType _itemType, int _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDesctription = _itemDec;
        itemType = _itemType;
        itemCount = _itemCount;
        itemIcon = Resources.Load("itemIcon/" + itemID.ToString(),typeof(Sprite)) as Sprite;
    }
}

[System.Serializable]
public class Weapon : Item
{
    public int weapon_AttackPower;
    public int weapon_Skill;
    public bool weapon_Type; // false = sword true : blunt
    public Weapon(int _itemID, string _itemName, string _itemDec, ItemType _itemType, int _weapon_AttackPower, int _weapon_Skill, bool _weapon_Type, int _itemCount = 1) : base(_itemID, _itemName, _itemDec, _itemType, _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDesctription = _itemDec;
        itemType = _itemType;
        itemIcon = Resources.Load("itemIcon/" + itemID.ToString(), typeof(Sprite)) as Sprite;
        weapon_AttackPower = _weapon_AttackPower;
        weapon_Skill = _weapon_Skill;
        weapon_Type = _weapon_Type;
        itemCount = _itemCount;

    }
}

[System.Serializable]
public class Potion : Item
{
    public int potion_Type; // 0 : HP // 1 : MP // 2 : Attack 
    public int potion_Volume;
    public int potion_Time;
    public int price;
    public int price_material;
    public Potion(int _itemID, string _itemName, string _itemDec, ItemType _itemType,int _potion_Type,int _potion_Volume ,int _potion_Time, int _price,int _price_material ,int _itemCount = 1) : base(_itemID, _itemName, _itemDec, _itemType, _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDesctription = _itemDec;
        itemType = _itemType;
        itemCount = _itemCount;
        itemIcon = Resources.Load("itemIcon/" + itemID.ToString(), typeof(Sprite)) as Sprite;
        potion_Type = _potion_Type;
        potion_Volume = _potion_Volume;
        potion_Time = _potion_Time;
        price = _price;
        price_material = _price_material;
        //itemIcon = Resources.Load("itemIcon/" + itemID.ToString(),typeof(Sprite)) as Sprite;
    }
}

[System.Serializable]
public class Material : Item
{
    public int material_Num;
    public Material(int _itemID, string _itemName, string _itemDec, ItemType _itemType, int _material_Num,int _itemCount = 1) : base(_itemID, _itemName, _itemDec, _itemType, _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDesctription = _itemDec;
        itemType = _itemType;
        itemCount = _itemCount;
        itemIcon = Resources.Load("itemIcon/" + itemID.ToString(), typeof(Sprite)) as Sprite;
        material_Num = _material_Num;
        //itemIcon = Resources.Load("itemIcon/" + itemID.ToString(),typeof(Sprite)) as Sprite;
    }
}
[System.Serializable]
public class Recipe
{
    public int ItemID;
    public int NeedItemsCount;
    public Item[] NeedItems;
    
    public Recipe(int _itemID, int _NeedItemsCount, Item _NeedItem1,Item _NeedItem2)
    {
        ItemID = _itemID;
        NeedItemsCount = _NeedItemsCount;
        Item[] arr = {_NeedItem1,_NeedItem2};
        NeedItems = arr;
  
    }
}
[System.Serializable] 
public class Stage
{
    public string StageName;
    public string StageDec;
    public int StageID;


    public Stage(string _StageName, string _StageDec, int _StageID )
    {
        StageName = _StageName;
        StageDec = _StageDec;
        StageID = _StageID;
    }
}
[System.Serializable]
public class Monster
{
    public int monsterID;
    public string monsterName;
    public int hp;
    public int atk;
    public bool boss;
    public Sprite asset;
    public Monster(int _monsetId, string _monsetName,int _hp,int _atk, bool _boss)
    {
        monsterID = _monsetId;
        monsterName = _monsetName;
        hp = _hp;
        atk = _atk;
        boss = _boss;
        asset = Resources.Load("itemIcon/" + monsterID.ToString(), typeof(Sprite)) as Sprite;
    }
}