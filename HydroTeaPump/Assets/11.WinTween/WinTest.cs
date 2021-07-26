using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WinTween.Position;

public class WinTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PositionEffects.Middle(0, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PositionEffects.BounceUp(2.0f, 200.0f);
        }
    }
}
