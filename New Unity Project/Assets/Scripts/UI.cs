using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    public GameObject canvas;

    

    public SaveNLoad saveload;
    public GameObject initscence;
    private MonsterPooling pool;

    private AudioSource audioSource;
    public AudioClip s_InvenOff;
    public AudioClip s_InvenOn;
    public AudioClip s_Button;




    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
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
        audioSource.clip = s_InvenOn;
        audioSource.Play();

        InvenNStatus.SetActive(true);
        Inventory.GetComponent<Inventory>().ViewInventory();
        CharaterStates.GetComponent<StatusUI>().View_Status();
    }
    public void Close_UI()
    {
        audioSource.clip = s_InvenOff;
        audioSource.Play();

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

    public void Open_ItemMake()
    {
        audioSource.clip = s_InvenOn;
        audioSource.Play();
        itemmakeUI.SetActive(true);
        
    }
    public void MakeItem()
    {
        audioSource.clip = s_Button;
        audioSource.Play();
        itemmakeUI.GetComponent<ItemMakeUI>().MakeItem(SelectedMake);
    }

    public void Opne_StageMove()
    {
        audioSource.clip = s_InvenOn;
        audioSource.Play();

        StageMove.SetActive(true);
    }
    
    public void moveStage()
    {
        SelectedStage.LoadStage();
        StageMove.SetActive(false);
    }

    public void InitScene()
    {
        canvas.SetActive(true);
        Close_UI();
        initscence.SetActive(false);
        
        
        playerstate.GetComponent<Transform>().position = new Vector2(-45, -15);
        StageManager.sminstance.OpenStage("Lobby");
        SceneManager.LoadScene("Lobby");
        
        /*
        saveload.CallLoad();
        Inventory.GetComponent<Inventory>().potionCountUpdate(1);
        Inventory.GetComponent<Inventory>().potionCountUpdate(2);*/
    }
    public void BackLobby()
    {
        pool = FindObjectOfType<MonsterPooling>();
        pool.StopCo();
        SceneManager.LoadScene("Lobby");
        StageManager.sminstance.OpenStage("Lobby");
        playerstate.GetComponent<Transform>().position = new Vector2(-45, -15);
        /*saveload.CallSave();*/
    }
    public void Open_potionMarchant()
    {
        audioSource.clip = s_InvenOn;
        audioSource.Play();

        potionMarket.SetActive(true);
    }
    public void Save()
    {
        saveload.CallSave();
    }
}
