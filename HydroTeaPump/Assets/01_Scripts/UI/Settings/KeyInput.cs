using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI.Management.Button;

public class KeyInput : MonoBehaviour
{
    [Header("입력받을 버튼과 그 텍스트")]
    [SerializeField] Button btnInput;
    [SerializeField] Text   txtPressed;

    [Header("세팅 패널")]
    [SerializeField] GameObject settingPannel;

    // 새 키 입력인 경우
    KeyCode newKey;

    [Header("설정하는 키")]
    [SerializeField] KeyMapEnum key;

    bool setEdit;

    void Start()
    {
        ButtonManagement.AddEvent(btnInput, SetEdit);
        txtPressed.text = OptionManager.GetSettings(key).ToString();
    }

    private void OnEnable()
    {
        setEdit = false;
    }

    private void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey && setEdit)
        {
            setEdit = false;
            txtPressed.text = e.keyCode.ToString();
            newKey = e.keyCode;
            OptionManager.KeyRemap(newKey, key);
        }
    }

    private void SetEdit()
    {
        setEdit = true;
    }
}
