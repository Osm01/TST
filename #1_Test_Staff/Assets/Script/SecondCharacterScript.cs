using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCharacterScript : MonoBehaviour
{
    public bool IsCol = false;
    CutSceneDialog cutSceneDialog;
    private void Awake()
    {
        cutSceneDialog = GameObject.Find("BackFlash").gameObject.GetComponent<CutSceneDialog>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            IsCol = true;
            cutSceneDialog._CutScene = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            IsCol = false;
            cutSceneDialog._CutScene = true;
        }
    }
}
