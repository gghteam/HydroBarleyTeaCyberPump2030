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

    private SettingsVO opt = new SettingsVO();

    private bool isStartPlaying = false;
    private void Start()
    {
        if(audioSource != null)
        {
            audioSource.clip = StageMusic[GameManager.Instance.currentStage];
        }

        SetVolume();
    }
    public void StartMusic()
    {
        audioSource.Play();
        isStartPlaying = true;
    }

    private void Update()
    {
        if(!audioSource.isPlaying && isStartPlaying)
        {
            noteManager.TimeOut();
        }
    }

    /// <summary>
    /// �ɼǿ� �ִ� �� �״�� ������ �����մϴ�.
    /// </summary>
    private void SetVolume()
    {
        opt = OptionManager.GetSettings();
        if (opt != null)
        {
            audioSource.volume = opt.musicVolume;
            return;
        }

        audioSource.volume = opt.musicVolume;
    }
}
