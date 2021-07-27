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
    }

    /// <summary>
    /// �ɼǿ� �ִ� �� �״�� ������ �����մϴ�.
    /// </summary>
    private void SetVolume()
    {
        opt = OptionManager.GetSettings();
        if (opt != null)
        {
            audioSource.volume = 0.8f;
            return;
        }

        audioSource.volume = opt.effectVolume;
    }
}
