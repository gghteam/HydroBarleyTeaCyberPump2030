using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class NoteManager : MonoBehaviour
{
    #region Setter

    /// <summary>
    /// BPM �� �����մϴ�.
    /// </summary>
    /// <param name="bpm">������ bpm</param>
    static public void SetBPM(int bpm)
    {
        inst.bpm = bpm;
    }

    /// <summary>
    /// BPM �� �ι� ������ �մϴ�
    /// </summary>
    static public void DoubleBPM()
    {
        inst.bpm *= 2;
    }

    /// <summary>
    /// BPM �� ������ ����ϴ�.
    /// </summary>
    static public void HalfBPM()
    {
        inst.bpm /= 2;
    }

    #endregion

    #region Getter

    /// <summary>
    /// ���� BPM �� �����մϴ�.
    /// </summary>
    /// <returns>current bpm</returns>
    static public int GetBPM()
    {
        return inst.bpm;
    }

    #endregion
}