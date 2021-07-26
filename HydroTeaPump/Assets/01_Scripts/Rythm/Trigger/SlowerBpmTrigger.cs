using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerBpmTrigger : TriggerBase
{
    /// <summary>
    /// Ÿ���� ������ BPM �� ������ ����
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bActivated || collision.gameObject.layer != whatIsPlayer) return;
        NoteManager.HalfBPM();
        bActivated = true;
    }
}
