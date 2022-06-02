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
    int indexChar;
    float timer = 0;
    bool isEnabled = false;
    private void Start()
    {
        CurrentDialog = 0;
        CurrentSentence = 0;
        indexChar = 0;
    }
    private void Update()
    {
        if (isEnabled)
        {
            timer -= Time.deltaTime;
            // should optimize this line for display next name with their sentences and problem with size of array in sentences 
            NameTxt.text = Qrd[CurrentDialog].Name;
            if (CurrentSentence < Qrd[CurrentDialog].Sentences.Length)
            {
                if (indexChar <= Qrd[CurrentDialog].Sentences[CurrentSentence].Length)
                {
                    if (timer <= 0)
                    {
                        AddWriter(DialogTxt, Qrd[CurrentDialog].Sentences[CurrentSentence]);
                        timer = .1f;
                        indexChar++;
                    }
                }
                else
                {
                    indexChar = 0;
                    CurrentSentence++;
                }
            }
            
           // CurrentSentence++;
        }
    }
    private void OnEnable()
    {
        isEnabled = true;
    }
    private void OnDisable()
    {
        isEnabled = false;
    }
    public void AddWriter(TMP_Text txt,string w)
    {
        txt.text = w.Substring(0,indexChar);
    }
}


