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
            audioSource.clip = StageMusic[/*GameManager.Instance.currentStage*/0];
            audioSource.Play();
        }

        SetVolume();
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
