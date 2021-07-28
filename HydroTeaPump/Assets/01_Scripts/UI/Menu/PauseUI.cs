using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI.Management.Button;

using DG.Tweening;

public class PauseUI : MonoBehaviour
{
    [Header("�Ͻ����� ��ư")]
    [SerializeField] private Button btnPause;

    [Header("�Ͻ����� �г�")]
    [SerializeField] private GameObject pausePannel;

    [Header("���θŴ� ���ư��� ��ư")]
    [SerializeField] private Button btnMainMenu;

    [Header("���θŴ� ���ư��� ��ư")]
    [SerializeField] private Button btnOption;

    [Header("�ݴ� ��ư")]
    [SerializeField] private Button btnClose;

    [Header("��ư Ŭ���� �̵� ��ġ")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform btnGroup;
                     private Vector3   origin; // �⺻ ��ġ

    [Header("��ư �̵� �ð�")]
    [SerializeField] private float duration = 1.0f;

    [Header("���� �г�")]
    [SerializeField] private GameObject settingPannel = null;

    // �Ͻ� ���� ���� Ȯ�� ��
    private bool isPause = false;


    private void Awake()
    {
        ButtonManagement.AddEvent(btnPause,  Pause);
        ButtonManagement.AddEvent(btnClose,  Pause);
        ButtonManagement.AddEvent(btnOption, BtnMovement);
        ButtonManagement.AddEvent(btnMainMenu, () => { UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); Time.timeScale = 1; }); // �� �̸��� �Ƹ� ���߿� �ٲ����

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
