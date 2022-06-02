using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class TextToSpeech : MonoBehaviour
{
    public InputField inputField;
    private const string url = "http://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q=";
    public AudioSource audioSource;




    public void Speech()
    {
        StartCoroutine(Convert());
    }
    IEnumerator Convert()
    {
        string _url = url + inputField.text + "&tl=En-gb";
        AudioClip audioClip;
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        {
            if (uwr.result == UnityWebRequest.Result.Success)
            {
                yield return uwr.SendWebRequest();
                audioClip = DownloadHandlerAudioClip.GetContent(uwr);
                audioSource.clip = audioClip;
                Debug.Log("Succes");
            }
            else
            {
                Debug.Log(uwr.error);
            }
        }
    }
}
