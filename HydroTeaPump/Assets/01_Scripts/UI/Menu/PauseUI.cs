using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIManagement.Button;

public class PauseUI : MonoBehaviour
{
    [Header("일시정지 버튼")]
    [SerializeField] private Button btnPause;

    [Header("일시정지 패널")]
    [SerializeField] private GameObject pausePannel;

    [Header("매인매뉴 돌아가는 버튼")]
    [SerializeField] private Button btnMainMenu;

    [Header("닫는 버튼")]
    [SerializeField] private Button btnClose;


    // 일시 정지 상태 확인 용
    private bool isPause = false;


    private void Awake()
    {
        ButtonManagement.AddEvent(btnPause, Pause);
        ButtonManagement.AddEvent(btnClose, Pause);
        ButtonManagement.AddEvent(btnMainMenu, () => { UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); }); // 신 이름은 아마 나중에 바뀔수도
    }

    private void Pause()
    {
        isPause        = !isPause;
        Time.timeScale = isPause ? 0 : 1;
        
        pausePannel.SetActive(isPause);
    }
}
