using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> Q_A;
    public Text QuestionTxt;
    public GameObject[] ButtonsTXT;
    int CurrentAnswer;
    int correctIndex = -1;

    private void Start()
    {
        CurrentAnswer = 0;
        SetQ_A();
    }
    public void GetAnswer(Image img)
    {
        //get index of current answer by default gonna take -1 
        for (int i = 0; i < Q_A[CurrentAnswer].Answers.Length; i++)
        { 
          if (EventSystem.current.currentSelectedGameObject.name == ButtonsTXT[i].name)
        {
                correctIndex = i;
        }
        }
        if (correctIndex == Q_A[CurrentAnswer].CorrectIndex)
        {
            ButtonsTXT[correctIndex].GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
        }
        else
        {
            ButtonsTXT[correctIndex].GetComponent<Image>().color = Color.red;
            Debug.Log("Not Correct Answer");

        }
        StartCoroutine(JustWaitASeconds());
       
       
       
    }
    public void SetQ_A()
    {
        if (Q_A.Count>0)
        {
            QuestionTxt.text = Q_A[CurrentAnswer].Qt;
            for (int i = 0; i < Q_A[CurrentAnswer].Answers.Length; i++)
            {
                ButtonsTXT[i].transform.GetChild(0).GetComponent<Image>().sprite = Q_A[CurrentAnswer].Answers[i];      
            }
            // could be increnment CurrentAnswer by 1 ==>CurrentAnswer++
        }
    }
    IEnumerator JustWaitASeconds()
    {
        yield return new WaitForSeconds(2f);
        CurrentAnswer++;
        SetQ_A();
        for (int i = 0; i < ButtonsTXT.Length; i++)
        {
            ButtonsTXT[correctIndex].GetComponent<Image>().color = Color.white;
        }
    }
}

