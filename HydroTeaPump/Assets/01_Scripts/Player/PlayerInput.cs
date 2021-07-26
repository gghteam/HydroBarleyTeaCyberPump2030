using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool left   { get; private set; } // 왼쪽 키 눌렀음을 의미
    public bool right  { get; private set; } // 오른쪽 키 눌렀음을 의미
    public bool select { get; private set; } // 선택 키 눌렀음을 의미

    // 키매핑 대응
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
