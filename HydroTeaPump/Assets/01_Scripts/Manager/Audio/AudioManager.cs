using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField]
    private AudioClip[] StageMusic;

    [SerializeField]
    private NoteManager noteManager;

    private void Start()
    {
        if(audioSource != null)
        {
            audioSource.clip = StageMusic[/*GameManager.Instance.currentStage*/0];
            audioSource.Play();
        }
        
    }
}
