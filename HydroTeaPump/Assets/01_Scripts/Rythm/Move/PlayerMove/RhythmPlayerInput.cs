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

    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;

    private void Awake()
    {
        upKey    = OptionManager.GetSettings().moveUp;
        downKey  = OptionManager.GetSettings().moveDown;
        leftKey  = OptionManager.GetSettings().moveLeft;
        rightKey = OptionManager.GetSettings().moveRight;
    }

    private void Update()
    {
        up    = Input.GetKeyDown(upKey);
        down  = Input.GetKeyDown(downKey);
        left  = Input.GetKeyDown(leftKey);
        right = Input.GetKeyDown(rightKey);
    }
}
