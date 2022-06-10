using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTSTCode : MonoBehaviour
{
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip[] audioClips;
    int AudioIndex = 0;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !audiosource.isPlaying)
        {
            Debug.Log(AudioIndex);
            audiosource.PlayOneShot(audioClips[AudioIndex]);
            AudioIndex++;
        }
        if(audiosource.isPlaying)
        {
            Debug.Log("Is Playing");
        }
    }
}
