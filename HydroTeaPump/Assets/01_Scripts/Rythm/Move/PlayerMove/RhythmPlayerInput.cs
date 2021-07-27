using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmPlayerInput : MonoBehaviour
{
    // ют╥б boolean
    public bool up    { get; private set; }
    public bool down  { get; private set; }
    public bool left  { get; private set; }
    public bool right { get; private set; }

    private KeyCode upKey    = KeyCode.UpArrow;
    private KeyCode downKey  = KeyCode.DownArrow;
    private KeyCode leftKey  = KeyCode.LeftArrow;
    private KeyCode rightKey = KeyCode.RightArrow;

    private void Awake()
    {
        if (OptionManager.GetSettings() != null)
        {
            upKey = OptionManager.GetSettings().moveUp;
            downKey = OptionManager.GetSettings().moveDown;
            leftKey = OptionManager.GetSettings().moveLeft;
            rightKey = OptionManager.GetSettings().moveRight;
        }
    }

    private void Update()
    {
        up    = Input.GetKeyDown(upKey);
        down  = Input.GetKeyDown(downKey);
        left  = Input.GetKeyDown(leftKey);
        right = Input.GetKeyDown(rightKey);
    }
}
