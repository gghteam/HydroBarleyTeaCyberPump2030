using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WinTween.Position;
using WinTween.Scale;

public class WinMoveMid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PositionEffects.Middle(0, true);
        ScaleEffects.ToWindowed(1280, 720, 0, true);
    }
}
