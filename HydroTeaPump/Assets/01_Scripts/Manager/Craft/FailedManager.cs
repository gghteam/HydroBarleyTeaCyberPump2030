using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedManager : MonoBehaviour
{
    [SerializeField] private CraftUI craft; // ���� ����

    static private FailedManager inst;

    private bool[] whatPassed = new bool[3]; // ���� ����

    private bool isInsted = false; // �̹� �޸𸮿� �ö󰬴���

    private void Awake()
    {
        if (isInsted) return;
        isInsted = true;
        inst = this;
        DontDestroyOnLoad(this);
    }


    /// <summary>
    /// ������ ��� ����� �־�Ӵϴ�
    /// </summary>
    /// <param name="whatPassed"></param>
    static public void AddSuccessInfo(bool[] whatPassed)
    {
        inst.whatPassed[0] = whatPassed[0];
        inst.whatPassed[1] = whatPassed[1];
        inst.whatPassed[2] = whatPassed[2];
    }


    static public bool[] GetSuccessInfo()
    {
        return inst.whatPassed;
    }
}
