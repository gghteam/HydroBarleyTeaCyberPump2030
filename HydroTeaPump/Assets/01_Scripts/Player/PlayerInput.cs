using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool left   { get; private set; } // ���� Ű �������� �ǹ�
    public bool right  { get; private set; } // ������ Ű �������� �ǹ�
    public bool select { get; private set; } // ���� Ű �������� �ǹ�

    // Ű���� ����
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode selectKey;

    private void Start()
    {
        leftKey = OptionManager.GetSettings().moveLeft;
        rightKey = OptionManager.GetSettings().moveRight;
        selectKey = OptionManager.GetSettings().select;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        left   = Input.GetKey(leftKey);
        right  = Input.GetKey(rightKey);
        if (Input.GetKeyDown(selectKey))
        {
            select = true;
        }
    }

    /// <summary>
    /// select boolean �� false �� �����մϴ�.
    /// </summary>
    public void DisableSelect()
    {
        select = false;
    }
}
