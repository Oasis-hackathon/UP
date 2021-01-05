using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
public class SaveNLoad : MonoBehaviour
{
    [System.Serializable]
   public class Data
    {
        public bool tutorial_Fin;
        public bool tutorial_Ing;
        public int tutorial_Step;

        public List<int> player_Inventory;
        public List<int> player_Inventory_Count;
        public int player_EquipItem;

    }
    public Player the_Player;

    private Data data;

    public void CallSave()
    {
        data.tutorial_Fin = DBmanager.instance.tutorial_Fin;
        data.tutorial_Ing = DBmanager.instance.tutorial_Ing;
        data.tutorial_Step = DBmanager.instance.tutorial_Step;

        for(int i = 0; i < Inventory.inveninstance.OwnItem.Count; i++)
        {
            data.player_Inventory[i] = Inventory.inveninstance.OwnItem[i].itemID;
            data.player_Inventory_Count[i] = Inventory.inveninstance.OwnItem[i].itemCount;
        }
        data.player_EquipItem = the_Player.equip.itemID;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/SaveFile.dat");

        bf.Serialize(file, data);
        file.Close();

        Debug.Log(Application.dataPath + "의 위치에 저장했습니다.");

    }
    public void CallLoad()
    {
        BinaryFormatter bf = new BinaryFormatter();
        
        try
        {
            FileStream file = File.Open(Application.dataPath + "/SaveFile.dat", FileMode.Open);
            if (file != null && file.Length > 0)
            {
                data = (Data)bf.Deserialize(file);

                DBmanager.instance.tutorial_Fin = data.tutorial_Fin;
                DBmanager.instance.tutorial_Ing = data.tutorial_Ing;
                DBmanager.instance.tutorial_Step = data.tutorial_Step;

                for (int i = 0; i < data.player_Inventory.Count; i++)
                {
                    int ID = data.player_Inventory[i];
                    int index = ID;
                    if (200 > ID && ID >= 100)
                    {
                        index = ID - 100;
                        Inventory.inveninstance.OwnItem[i] = DBmanager.instance.weaponList[index];
                        Inventory.inveninstance.OwnItem[i].itemCount = data.player_Inventory_Count[i];
                    }
                    if (300 > ID && ID >= 200)
                    {
                        index = ID - 200;
                        Inventory.inveninstance.OwnItem[i] = DBmanager.instance.potionList[index];
                        Inventory.inveninstance.OwnItem[i].itemCount = data.player_Inventory_Count[i];
                    }
                    if (400 > ID && ID >= 300)
                    {
                        index = ID - 300;
                        Inventory.inveninstance.OwnItem[i] = DBmanager.instance.materialList[index];
                        Inventory.inveninstance.OwnItem[i].itemCount = data.player_Inventory_Count[i];
                    }
                }
                the_Player.fitIn(DBmanager.instance.weaponList[data.player_EquipItem - 100]);
            }
        }
        catch(FileNotFoundException ie)
        {
            Debug.Log(ie);
            DBmanager.instance.tutorial_Fin = false;
            DBmanager.instance.tutorial_Ing = false;
            DBmanager.instance.tutorial_Step = 0;
        }
        

    }

}
