using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool left   { get; private set; } // ���� Ű �������� �ǹ�
    public bool right  { get; private set; } // ������ Ű �������� �ǹ�
    public bool select { get; private set; } // ���� Ű �������� �ǹ�

    // Ű���� ����
    public KeyCode leftKey   = KeyCode.A;
    public KeyCode rightKey  = KeyCode.D;
    public KeyCode selectKey = KeyCode.Return;

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

    public void DisableSelect()
    {
        select = false;
    }
}
