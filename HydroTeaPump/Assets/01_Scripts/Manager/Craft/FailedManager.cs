using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedManager : MonoBehaviour
{
    [SerializeField] private CraftUI craft; // 실패 원인

    static private FailedManager inst;

    private bool[] whatPassed = new bool[3]; // 제작 정보

    private bool isInsted = false; // 이미 메모리에 올라갔는지

    private void Awake()
    {
        if (isInsted) return;
        isInsted = true;
        inst = this;
        DontDestroyOnLoad(this);
    }


    /// <summary>
    /// 성공한 재료 기록을 넣어둡니다
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
