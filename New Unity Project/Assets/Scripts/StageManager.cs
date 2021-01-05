using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageManager : MonoBehaviour
{
    public static StageManager sminstance;

    public GameObject inventory;
    public GameObject makeItem;
    public GameObject moveController;
    public GameObject potionController1;
    public GameObject potionController2;
    public GameObject attackController;
    public GameObject lobby;
    public GameObject potal;
    public GameObject potionmarket;

    public GameObject[] NormalMonster;
    public GameObject[] BossMonster;
    public void Awake()
    {
        sminstance = this;
    }
    private void Update()
    {
       
    }
    public void OpenStage(string str)
    {
        if(str == "Lobby")
        {
            Debug.Log("로비입네다.");
            inventory.SetActive(true);
            makeItem.SetActive(true);

            potionController1.SetActive(false);
            potionController2.SetActive(false);

            attackController.SetActive(false);
            lobby.SetActive(false);
            potal.SetActive(true);
            potionmarket.SetActive(true);

            return;
        }
        Debug.Log("로비가 아닙네다");
        
        inventory.SetActive(false);
        makeItem.SetActive(false);

        potionController1.SetActive(true);
        potionController2.SetActive(true);

        attackController.SetActive(true);
        lobby.SetActive(true);
        potal.SetActive(false);
        potionmarket.SetActive(false);
    }
}
