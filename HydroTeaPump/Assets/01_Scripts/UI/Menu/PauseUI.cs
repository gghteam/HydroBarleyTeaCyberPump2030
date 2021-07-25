using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIManagement.Button;

public class PauseUI : MonoBehaviour
{
    [Header("�Ͻ����� ��ư")]
    [SerializeField] private Button btnPause;

    [Header("�Ͻ����� �г�")]
    [SerializeField] private GameObject pausePannel;

    [Header("���θŴ� ���ư��� ��ư")]
    [SerializeField] private Button btnMainMenu;

    [Header("�ݴ� ��ư")]
    [SerializeField] private Button btnClose;


    // �Ͻ� ���� ���� Ȯ�� ��
    private bool isPause = false;


    private void Awake()
    {
        ButtonManagement.AddEvent(btnPause, Pause);
        ButtonManagement.AddEvent(btnClose, Pause);
        ButtonManagement.AddEvent(btnMainMenu, () => { UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); }); // �� �̸��� �Ƹ� ���߿� �ٲ����
    }

    private void Pause()
    {
        isPause        = !isPause;
        Time.timeScale = isPause ? 0 : 1;
        
        pausePannel.SetActive(isPause);
    }
}
