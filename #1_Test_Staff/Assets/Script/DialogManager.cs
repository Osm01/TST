using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogManager : MonoBehaviour
{
    //problem still here 1/6/2022
    public List<QuestionResponseDialog> Qrd;
    [SerializeField] TMP_Text DialogTxt;
    [SerializeField] TMP_Text NameTxt;
    int currentIndex;
    private void Start()
    {
        currentIndex = 0;
    }
    void SetTxts()
    {
        DialogTxt.text = Qrd[currentIndex].Question;
        NameTxt.text = Qrd[currentIndex].Name;
    }
}

[SerializeField]
public class QuestionResponseDialog
{
    public string Name;
    public string Question;
    public string Response;
}
