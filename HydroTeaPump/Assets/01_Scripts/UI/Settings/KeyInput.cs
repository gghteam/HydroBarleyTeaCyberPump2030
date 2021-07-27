using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI.Management.Button;

public class KeyInput : MonoBehaviour
{
    [Header("�Է¹��� ��ư�� �� �ؽ�Ʈ")]
    [SerializeField] Button btnInput;
    [SerializeField] Text   txtPressed;

    [Header("���� �г�")]
    [SerializeField] GameObject settingPannel;

    // �� Ű �Է��� ���
    KeyCode newKey;

    [Header("�����ϴ� Ű")]
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
