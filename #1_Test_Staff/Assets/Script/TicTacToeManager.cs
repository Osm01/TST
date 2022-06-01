using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TicTacToeManager : MonoBehaviour
{
    [SerializeField] Button[] bts;
    bool _LockPlay;
    bool _Winner;
    bool _AIPLayed;
    string Winner;
    private void Start()
    {
        InitGame();
    }
    private void Update()
    {
        if (_LockPlay)
        {
            // ClassicAIplay();
            AI_Play();
        }
    }
    public void PLayerClick()
    {
        //see if player have empty place to play it 
        // lockplay is variable see player turn or not
        if (!_LockPlay)
        {
            if (EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text == string.Empty)
            {
                EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text = "X";
            }
            _LockPlay = true;
        }
    }
    void InitGame()
    {
      _LockPlay = false;
        Winner = string.Empty;
        _Winner = false;
        _AIPLayed = false;
      for (int i = 0; i < bts.Length; i++)
      {
         bts[i].transform.GetChild(0).GetComponent<Text>().text = string.Empty;
      }
    }
    void AI_Play()
    {
        float BestScore = -Mathf.Infinity;
        float Move = 0;
        int bestspot = 0;
        for (int i = 0; i < bts.Length; i++)
        {
            if (bts[i].transform.GetChild(0).GetComponent<Text>().text == string.Empty)
            {
                bts[i].transform.GetChild(0).GetComponent<Text>().text = "O";
                Move = MiniMax(bts,false);
               // Debug.Log("IS :"+Move);
                bts[i].transform.GetChild(0).GetComponent<Text>().text = string.Empty;
                if (Move > BestScore)
                {
                    BestScore = Move;
                    bestspot = i;
                }
                Debug.Log("the position " + i + " with a score of " + Move);
            }
        }
        bts[bestspot].transform.GetChild(0).GetComponent<Text>().text = "O";
        Debug.Log("best position " + bestspot + " with a score of " + BestScore);
        _LockPlay = false;
    }

    private float MiniMax(Button[] bts,bool IsMax)
    {
        float Score = CheckWinner();
        float BestScore = 0f;
        if (Score != 0)
        {
            return Score;
        }
        if (IsMax)
        {
            BestScore = -Mathf.Infinity;
            for (int i = 0; i < bts.Length; i++)
            {
                if (bts[i].transform.GetChild(0).GetComponent<Text>().text == string.Empty)
                {
                    bts[i].transform.GetChild(0).GetComponent<Text>().text = "O";
                    float scoref = MiniMax(bts, false);
                    bts[i].transform.GetChild(0).GetComponent<Text>().text = string.Empty;
                    Score += scoref;
                }
            }
        }
        else
        {
             BestScore = Mathf.Infinity;
            for (int i = 0; i < bts.Length; i++)
            {
                if (bts[i].transform.GetChild(0).GetComponent<Text>().text == string.Empty)
                {
                    bts[i].transform.GetChild(0).GetComponent<Text>().text = "X";
                    float scoref = MiniMax(bts, true);
                    bts[i].transform.GetChild(0).GetComponent<Text>().text = string.Empty;
                    Score += scoref;
                }
            }
        }
        return Score;

    }

    bool IsWin(string isWinning)
    {
        bool _Winner = false;
        string bt0 = bts[0].transform.GetChild(0).GetComponent<Text>().text;
        string bt1 = bts[1].transform.GetChild(0).GetComponent<Text>().text;
        string bt2 = bts[2].transform.GetChild(0).GetComponent<Text>().text;
        string bt3 = bts[3].transform.GetChild(0).GetComponent<Text>().text;
        string bt4 = bts[4].transform.GetChild(0).GetComponent<Text>().text;
        string bt5 = bts[5].transform.GetChild(0).GetComponent<Text>().text;
        string bt6 = bts[6].transform.GetChild(0).GetComponent<Text>().text;
        string bt7 = bts[7].transform.GetChild(0).GetComponent<Text>().text;
        string bt8 = bts[8].transform.GetChild(0).GetComponent<Text>().text;

        if (bt0==bt1 && bt1==bt2 && bt2==isWinning)
        {
            _Winner = true;
        }
        if (bt3 == bt4 && bt4 == bt5 && bt5 == isWinning)
        {
            _Winner = true;
        }
        if (bt6 == bt7 && bt7 == bt8 && bt8 == isWinning)
        {
            _Winner = true;
        }
        if (bt0 == bt4 && bt4 == bt8 && bt8 == isWinning)
        {
            _Winner = true;
        }
        if (bt2 == bt4 && bt4 == bt6 && bt6 == isWinning)
        {
            _Winner = true;
        }
        if (bt0 == bt3 && bt3 == bt6 && bt6 == isWinning)
        {
            _Winner = true;
        }
        if (bt1 == bt4 && bt3 == bt7 && bt7 == isWinning)
        {
            _Winner = true;
        }
        if (bt2 == bt5 && bt5 == bt8 && bt8 == isWinning)
        {
            _Winner = true;
        }
        return _Winner;
    }
    void ClassicAIplay()
    {
        for (int i = 0; i < bts.Length; i++)
        {
            if (bts[i].transform.GetChild(0).GetComponent<Text>().text == string.Empty)
            {
                bts[i].transform.GetChild(0).GetComponent<Text>().text = "X";
                _Winner = IsWin("X");
                if (_Winner)
                {
                    bts[i].transform.GetChild(0).GetComponent<Text>().text = "O";
                    _AIPLayed = true;
                    break;
                }
                else
                {
                    bts[i].transform.GetChild(0).GetComponent<Text>().text = string.Empty;
                }
                bts[i].transform.GetChild(0).GetComponent<Text>().text = "O";
                _Winner = IsWin("O");
                if (_Winner)
                {
                    bts[i].transform.GetChild(0).GetComponent<Text>().text = "O";
                    _AIPLayed = true;
                    break;
                }
                else
                {
                    bts[i].transform.GetChild(0).GetComponent<Text>().text = string.Empty;
                }
            }

        }
        if ((!IsWin("O") || !IsWin("X")) && !_AIPLayed)
        {
            for (int y = 0; y < bts.Length; y++)
            {
                if (bts[y].transform.GetChild(0).GetComponent<Text>().text == string.Empty)
                {
                    bts[y].transform.GetChild(0).GetComponent<Text>().text = "O";
                    break;
                }

            }
        }
        _AIPLayed = false;
        _LockPlay = false;

    }
    int CheckWinner()
    {
        int VarWinner = 0;
        string bt0 = bts[0].transform.GetChild(0).GetComponent<Text>().text;
        string bt1 = bts[1].transform.GetChild(0).GetComponent<Text>().text;
        string bt2 = bts[2].transform.GetChild(0).GetComponent<Text>().text;
        string bt3 = bts[3].transform.GetChild(0).GetComponent<Text>().text;
        string bt4 = bts[4].transform.GetChild(0).GetComponent<Text>().text;
        string bt5 = bts[5].transform.GetChild(0).GetComponent<Text>().text;
        string bt6 = bts[6].transform.GetChild(0).GetComponent<Text>().text;
        string bt7 = bts[7].transform.GetChild(0).GetComponent<Text>().text;
        string bt8 = bts[8].transform.GetChild(0).GetComponent<Text>().text;

        if (bt0 == bt1 && bt1 == bt2 && bt2 == "X")
        {
            VarWinner = -10;
        }
        else if (bt0 == bt1 && bt1 == bt2 && bt2 == "O")
        {
            VarWinner = 10;
        }
        if (bt3 == bt4 && bt4 == bt5 && bt5 == "X")
        {
            VarWinner = -10;
        }
        else if (bt3 == bt4 && bt4 == bt5 && bt5 == "O")
        {
            VarWinner = 10;
        }
        if (bt6 == bt7 && bt7 == bt8 && bt8 == "X")
        {
            VarWinner = -10;
        }
        else if (bt6 == bt7 && bt7 == bt8 && bt8 == "O")
        {
            VarWinner = 10;
        }
        if (bt0 == bt4 && bt4 == bt8 && bt8 == "X")
        {
            VarWinner = -10;
        }
        else if (bt0 == bt4 && bt4 == bt8 && bt8 == "O")
        {
            VarWinner = 10;
        }
        if (bt2 == bt4 && bt4 == bt6 && bt6 == "X")
        {
            VarWinner = -10;
        }
        else if (bt2 == bt4 && bt4 == bt6 && bt6 == "O")
        {
            VarWinner = 10;
        }
        if (bt0 == bt3 && bt3 == bt6 && bt6 == "X")
        {
            VarWinner = -10;
        }
        else if (bt0 == bt3 && bt3 == bt6 && bt6 == "O")
        {
            VarWinner = 10;
        }
        if (bt1 == bt4 && bt3 == bt7 && bt7 == "X")
        {
            VarWinner = -10;
        }
        else if (bt1 == bt4 && bt3 == bt7 && bt7 == "O")
        {
            VarWinner = 10;
        }
        if (bt2 == bt5 && bt5 == bt8 && bt8 == "X")
        {
            VarWinner = -10;
        }
        else if (bt2 == bt5 && bt5 == bt8 && bt8 == "O")
        {
            VarWinner = 10;
        }

        return VarWinner;
    }
    }
