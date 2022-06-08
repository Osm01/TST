using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
public class TSTCode : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public Button btnYes;
    public Button btnNo;
    
    private void Awake()
    {
        string qt = "Do u want to quit the Game!!";
        ShowDialog(qt, () => { Debug.Log("yes"); },() => { Debug.Log("No"); }) ;
    }
    void ShowDialog(string TxtDialog,Action actionYes,Action actionNo)
    {
        textMeshProUGUI.text = TxtDialog;
        //if button preess trigger the action (two way of trigger button with action)
        btnYes.onClick.AddListener(() => { actionYes(); });
        btnNo.onClick.AddListener(new UnityEngine.Events.UnityAction(actionNo));
    }
}
