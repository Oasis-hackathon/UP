using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageMoveSlot : MonoBehaviour
{
    public TextMeshProUGUI Stagename;
    public TextMeshProUGUI StageDec;
    public Stage stage;

    public void SelectStage()
    {
        Stagename.text = stage.StageName;
        StageDec.text = stage.StageDec;
        UI.UIinstance.SelectedStage = this;
    }
    public void LoadStage()
    {
        SceneManager.LoadScene(stage.StageName);
        StageManager.sminstance.OpenStage(stage.StageName);

        Debug.Log("호 영 조 아");
    }
   
}
