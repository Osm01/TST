using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Assist : MonoBehaviour
{
    private Text ui_txt;
    private List<string> Words;
    private int indexCharacter;
    private int indexOfList;
    [SerializeField] float timer;
    private void Awake()
    {
        ui_txt = GameObject.Find("TextUI").GetComponent<Text>();
        ui_txt.text = "Start Function !!";
    }
  
    void Start()
    {
        Words = new List<string>();
        Words.Add("Hello Wordl !!");
        Words.Add("I'm Nabih");
        indexCharacter = 0;
        indexOfList = 0;
    }

    void AddWriter(Text text,string w)
    {
        text.text = w.Substring(0, indexCharacter);
    }
    void Update()
    {
        if (ui_txt != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                if (indexCharacter < Words[indexOfList].Length)
                {
                    indexCharacter++;
                    AddWriter(ui_txt, Words[indexOfList].ToString());
                    //reset timer by 1 
                    timer = .1f;
                }
                else
                {
                    //freeze timer on 0 see 
                    timer = 0;
                    //After First phrase finish ==> click on screen (order to go next phrase)
                    if (Input.touchCount > 0)
                    {
                        Debug.Log(Words[indexOfList].ToString());
                        //reset timer and index to start new word
                        timer = 1;
                        indexCharacter = 0;
                        indexOfList=1;
                    }
                }
               
            }
        }
    }
}
