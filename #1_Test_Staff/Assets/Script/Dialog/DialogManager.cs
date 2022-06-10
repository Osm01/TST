using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public List<Dialog> Qrd;
    [SerializeField] TMP_Text DialogTxt;
    [SerializeField] TMP_Text NameTxt;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    private MovementInput MovePlayer;
    private CutSceneDialog cutSceneDialog;
    int CurrentDialog;
    int CurrentSentence;
    int indexChar;
    float timer = 0;
    bool isEnabled = false;
    private int audioIndex = 0;
    private void Start()
    {
        CurrentDialog = 0;
        CurrentSentence = 0;
        indexChar = 0;
        MovePlayer = FindObjectOfType<MovementInput>();
        cutSceneDialog = FindObjectOfType<CutSceneDialog>();
        //AudioPlay();
    }
    private void Update()
    {
        
        if (isEnabled)
        {
            AudioPlay();
            cutSceneDialog.CanvasDialog.gameObject.SetActive(true);
            MovePlayer.enabled = false;
            timer -= Time.deltaTime;
            if (CurrentDialog < Qrd.Count)
            {
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
                else
                {
                    CurrentSentence = 0;
                    indexChar = 0;
                    CurrentDialog++;
                }
               
            }
            // End of dialog make 
            else
            {
                isEnabled = false;
            }
        }
        else
        {
            CurrentSentence = 0;
            indexChar = 0;
            CurrentDialog=0;
            cutSceneDialog.CanvasDialog.gameObject.SetActive(false);
            MovePlayer.enabled = true;
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

   
    void AudioPlay()
    {
           if (!audioSource.isPlaying && CurrentDialog == 0 && CurrentSentence == 0)
            {
                if (audioIndex != 0)
                  return;
                audioSource.PlayOneShot(audioClips[audioIndex]);
                audioIndex++;
            }
            if (!audioSource.isPlaying && CurrentDialog == 0 && CurrentSentence == 1)
            {
            if (audioIndex != 1)
                return;
                audioSource.PlayOneShot(audioClips[audioIndex]);
               audioIndex++;
            }
            if (!audioSource.isPlaying && CurrentDialog == 1 && CurrentSentence == 0)
            {
                if (audioIndex != 2)
                return;
                audioSource.PlayOneShot(audioClips[audioIndex]);
                audioIndex++;
            }
            if (!audioSource.isPlaying && CurrentDialog == 1 && CurrentSentence == 1)
            {
                if (audioIndex != 3)
                return;
                audioSource.PlayOneShot(audioClips[audioIndex]);
               audioIndex++;
            }
           
    }
}


