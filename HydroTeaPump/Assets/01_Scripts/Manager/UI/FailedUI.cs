using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailedUI : MonoBehaviour
{
    private bool[] createInfo = new bool[3];

    [SerializeField] private Text reasonText = null;


    private void Start()
    {
        createInfo = FailedManager.GetSuccessInfo();
    }

    /// <summary>
    /// ������ ��Ḧ �ø�
    /// </summary>
    public void SetText()
    {
        reasonText.text = $"�ùٸ� ���: {(createInfo[0] ? "���������� " : "")}��{(createInfo[1] ? "���봫�� " : "")} , {(createInfo[2] ? "�Ȱ�����" : "")}";
    }

}
