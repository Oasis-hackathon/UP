using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMoveUI : MonoBehaviour
{
    public GameObject StageslotP;
    public StageMoveSlot[] StageMoveSlots;

    private void Start()
    {
        StageMoveSlots = StageslotP.GetComponentsInChildren<StageMoveSlot>();
        for(int i = 1; i < DBmanager.instance.stageList.Count; i++)
        {
            StageMoveSlots[i-1].stage = DBmanager.instance.stageList[i];
        }
    }
}
