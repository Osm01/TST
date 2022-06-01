using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogManager : MonoBehaviour
{
    public List<Dialog> Qrd;
    [SerializeField] TMP_Text DialogTxt;
    [SerializeField] TMP_Text NameTxt;
    int CurrentDialog;
    int CurrentSentence;
    private void Start()
    {
        CurrentDialog = 0;
        CurrentSentence = 0;
    }
    void SetDialog()
    {
        DialogTxt.text = Qrd[CurrentDialog].Sentences[CurrentSentence];
        NameTxt.text = Qrd[CurrentDialog].Name;
    }
}


