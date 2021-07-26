using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class NoteManager : MonoBehaviour
{
    #region Setter

    /// <summary>
    /// BPM 을 설정합니다.
    /// </summary>
    /// <param name="bpm">설정할 bpm</param>
    static public void SetBPM(int bpm)
    {
        inst.bpm = bpm;
    }

    /// <summary>
    /// BPM 을 두배 빠르게 합니다
    /// </summary>
    static public void DoubleBPM()
    {
        inst.bpm *= 2;
    }

    /// <summary>
    /// BPM 을 반으로 늦춥니다.
    /// </summary>
    static public void HalfBPM()
    {
        inst.bpm /= 2;
    }

    #endregion

    #region Getter

    /// <summary>
    /// 현제 BPM 을 리턴합니다.
    /// </summary>
    /// <returns>current bpm</returns>
    static public int GetBPM()
    {
        return inst.bpm;
    }

    #endregion
}