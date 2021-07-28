using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI.Management.Button;

using DG.Tweening;

public class PauseUI : MonoBehaviour
{
    [Header("일시정지 버튼")]
    [SerializeField] private Button btnPause;

    [Header("일시정지 패널")]
    [SerializeField] private GameObject pausePannel;

    [Header("매인매뉴 돌아가는 버튼")]
    [SerializeField] private Button btnMainMenu;

    [Header("매인매뉴 돌아가는 버튼")]
    [SerializeField] private Button btnOption;

    [Header("닫는 버튼")]
    [SerializeField] private Button btnClose;

    [Header("버튼 클릭시 이동 위치")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform btnGroup;
                     private Vector3   origin; // 기본 위치

    [Header("버튼 이동 시간")]
    [SerializeField] private float duration = 1.0f;

    [Header("설정 패널")]
    [SerializeField] private GameObject settingPannel = null;

    // 일시 정지 상태 확인 용
    private bool isPause = false;


    private void Awake()
    {
        ButtonManagement.AddEvent(btnPause,  Pause);
        ButtonManagement.AddEvent(btnClose,  Pause);
        ButtonManagement.AddEvent(btnOption, BtnMovement);
        ButtonManagement.AddEvent(btnMainMenu, () => { UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); Time.timeScale = 1; }); // 신 이름은 아마 나중에 바뀔수도

        origin = btnGroup.position;

        pausePannel.SetActive(false);
        btnPause.gameObject.SetActive(true);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(OptionManager.GetSettings().exit))
        {
            Pause();
        }
    }

    private void Pause()
    {
        isPause        = !isPause;
        Time.timeScale = isPause ? 0 : 1;
        
        pausePannel.SetActive(isPause);
        btnPause.gameObject.SetActive(!isPause);
        settingPannel.SetActive(false);
        btnGroup.position = origin;
    }

    
    private void BtnMovement()
    {
        bool shutdown = false;

        Time.timeScale = 1;
        if (settingPannel.activeSelf)
        {
            settingPannel.SetActive(false);
            shutdown = true;
        }
        btnGroup.DOMove(shutdown ? origin : target.position, duration).SetEase(Ease.InOutQuad).OnComplete(() => 
        { 
            Time.timeScale = 0;

            if (!shutdown)
            {
                settingPannel.gameObject.SetActive(true);
            }
        });
    }
}
