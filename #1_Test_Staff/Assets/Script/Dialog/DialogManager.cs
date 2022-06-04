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
    bool _audioPlayed = true;
    bool WaitForAudio = false;
    private void Start()
    {
        CurrentDialog = 0;
        CurrentSentence = 0;
        indexChar = 0;
        MovePlayer = FindObjectOfType<MovementInput>();
        cutSceneDialog = FindObjectOfType<CutSceneDialog>();
        AudioPlay();
    }
    private void Update()
    {
        
        if (isEnabled)
        {
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
                        WaitForAudio = true;
                        if (timer <= 0)
                        {
                            AddWriter(DialogTxt, Qrd[CurrentDialog].Sentences[CurrentSentence]);
                            timer = .1f;
                            indexChar++;
                        }
                    }

                    else
                    {
                        if(!WaitForAudio)
                        {
                            _audioPlayed = true;
                            indexChar = 0;
                            CurrentSentence++;
                        }
                    }
                }
                else
                {
                    _audioPlayed = true;
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
        while(isEnabled)
        {
            if (CurrentDialog == 0 && CurrentSentence == 0)
            {
                audioSource.PlayOneShot(audioClips[0]);
            }
            if (CurrentDialog == 0 && CurrentSentence == 1)
            {
                audioSource.PlayOneShot(audioClips[1]);
            }
            if (CurrentDialog == 1 && CurrentSentence == 0)
            {
                audioSource.PlayOneShot(audioClips[2]);
            }
            if (CurrentDialog == 1 && CurrentSentence == 1)
            {
                audioSource.PlayOneShot(audioClips[3]);
            }
            if (!audioSource.isPlaying)
            {
                WaitForAudio = false;
            }
        }
       
        
    }
}


