using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool IsCorrect=false;
    public void Answer()
    {
        if (IsCorrect)
        {
            Debug.Log("Is Correct");
        }
        else
        {
            Debug.Log("Not Correct");

        }
    }
}
