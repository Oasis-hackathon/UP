using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    public static UI UIinstance;
    public GameObject Player;

    public Slider PlayerHpSlider;

    public GameObject Conversation;
    public Text conversationText;

    public GameObject Inventory;
    public GameObject CharaterStates;
    public GameObject InvenNStatus;
    public InventorySlot SelectedSlot;

    public GameObject itemmakeUI;
    public MakeItemSlot SelectedMake;

    public StageMoveSlot SelectedStage;
    public GameObject StageMove;

    public GameObject potionMarket;

    private Player playerstate;


    public GameObject initscence;
    private void Start()
    {
        playerstate = Player.GetComponent<Player>();
        UIinstance = this;
    }
    private void Update()
    {
        
        PlayerHpSlider.maxValue = playerstate.HP;
       
        PlayerHpSlider.value = playerstate.CurrentHP;
       
    }
    public void ConversationOpen(string _dialogue)
    {
        // 대화를 띄워주는 코드
    }
    public void InfoOpen()
    {

    }
    public void Open_InvenNStatus()
    {
        InvenNStatus.SetActive(true);
        Inventory.GetComponent<Inventory>().ViewInventory();
        CharaterStates.GetComponent<StatusUI>().View_Status();
    }
    public void Close_UI()
    {
        itemmakeUI.GetComponent<ItemMakeUI>().ClearSlots();

        InvenNStatus.SetActive(false);
        itemmakeUI.SetActive(false);
        StageMove.SetActive(false);
        potionMarket.SetActive(false);
    }
    public void ItemUse()
    {
        SelectedSlot.Use_Button();
    }
    public void potionResigist()
    {
        SelectedSlot.registerPotion1();
    }
    public void Open_ItemMake()
    {
        itemmakeUI.SetActive(true);
        
    }
    public void MakeItem()
    {
        itemmakeUI.GetComponent<ItemMakeUI>().MakeItem(SelectedMake);
    }

    public void Opne_StageMove()
    {
        StageMove.SetActive(true);
    }
    
    public void moveStage()
    {
        SelectedStage.LoadStage();
        StageMove.SetActive(false);
    }

    public void InitScene()
    {
        initscence.SetActive(false);
        SceneManager.LoadScene("Lobby");
        
        playerstate.GetComponent<Transform>().position = new Vector2(-45, -15);
        StageManager.sminstance.OpenStage("Lobby");

    }
    public void BackLobby()
    {
        SceneManager.LoadScene("Lobby");
        StageManager.sminstance.OpenStage("Lobby");
        playerstate.GetComponent<Transform>().position = new Vector2(-45, -15);
    }
    public void Open_potionMarchant()
    {
        potionMarket.SetActive(true);
    }
}
