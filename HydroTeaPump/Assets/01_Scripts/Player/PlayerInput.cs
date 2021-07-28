using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool left   { get; private set; } // 왼쪽 키 눌렀음을 의미
    public bool right  { get; private set; } // 오른쪽 키 눌렀음을 의미
    public bool select { get; private set; } // 선택 키 눌렀음을 의미
    public bool exit   { get; private set; } // 뒤로가기 키 눌렀음을 의미

    // 키매핑 대응
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
    /// select boolean 을 false 로 설정합니다.
    /// </summary>
    public void DisableSelect()
    {
        select = false;
    }

    /// <summary>
    /// exit boolean 을 false 로 설정합니다
    /// </summary>
    public void DisableExit()
    {
        exit = false;
    }
}
