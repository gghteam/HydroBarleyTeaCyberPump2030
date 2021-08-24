using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField]
    private AudioClip[] StageMusic;

    [SerializeField]
    private PuzzleManager puzzleManager;

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

    private void Update()
    {
        if(!audioSource.isPlaying)
        {
            //puzzleManager.TimeOut();
        }
    }

    /// <summary>
    /// 옵션에 있는 값 그대로 볼륨을 설정합니다.
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
