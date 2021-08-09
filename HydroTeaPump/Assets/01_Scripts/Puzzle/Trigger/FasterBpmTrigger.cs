using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterBpmTrigger : TriggerBase
{
    /// <summary>
    /// 타일을 밟으면 BPM 을 두배로 설정함
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bActivated || collision.gameObject.layer != whatIsPlayer) return;
        NoteManager.DoubleBPM();
        bActivated = true;
    }
}
