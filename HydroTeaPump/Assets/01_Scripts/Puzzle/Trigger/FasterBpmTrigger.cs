using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterBpmTrigger : TriggerBase
{
    /// <summary>
    /// Ÿ���� ������ BPM �� �ι�� ������
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bActivated || collision.gameObject.layer != whatIsPlayer) return;
        NoteManager.DoubleBPM();
        bActivated = true;
    }
}
