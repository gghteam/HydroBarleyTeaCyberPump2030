using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool left   { get; private set; } // ���� Ű �������� �ǹ�
    public bool right  { get; private set; } // ������ Ű �������� �ǹ�
    public bool select { get; private set; } // ���� Ű �������� �ǹ�
    public bool exit   { get; private set; } // �ڷΰ��� Ű �������� �ǹ�

    // Ű���� ����
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode selectKey;
    private KeyCode exitKey;

    private void Start()
    {
        leftKey = OptionManager.GetSettings().moveLeft;
        rightKey = OptionManager.GetSettings().moveRight;
        selectKey = OptionManager.GetSettings().select;
        exitKey = OptionManager.GetSettings().exit;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        left   = Input.GetKey(OptionManager.GetSettings().moveLeft);
        right  = Input.GetKey(OptionManager.GetSettings().moveRight);
        if (Input.GetKeyDown(OptionManager.GetSettings().select))
        {
            select = true;
        }
        if (Input.GetKeyDown(OptionManager.GetSettings().exit))
        {
            exit = true;
        }
    }

    /// <summary>
    /// select boolean �� false �� �����մϴ�.
    /// </summary>
    public void DisableSelect()
    {
        select = false;
    }

    /// <summary>
    /// exit boolean �� false �� �����մϴ�
    /// </summary>
    public void DisableExit()
    {
        exit = false;
    }
}
