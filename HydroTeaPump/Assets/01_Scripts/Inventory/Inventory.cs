using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Button[] btnList;

    static public ItemVO item = null;

    private void Awake()
    {
        // �κ��丮 ĭ ���� ������ ��
        btnList = GetComponentsInChildren<Button>();
    }

    // TODO : ��������

}
