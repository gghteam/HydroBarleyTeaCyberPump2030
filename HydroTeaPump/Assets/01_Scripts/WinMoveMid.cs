using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_STANDALONE_WIN || !UNITY_EDITOR_LINUX

using WinTween.Position;
using WinTween.Scale;

public class WinMoveMid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PositionEffects.Middle(0, true);
        ScaleEffects.ToWindowed(1600, 900, 0, true);
    }
}

#endif