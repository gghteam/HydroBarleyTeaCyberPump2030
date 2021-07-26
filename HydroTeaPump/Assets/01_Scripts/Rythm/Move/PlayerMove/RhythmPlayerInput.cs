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

    [SerializeField] private KeyCode upKey    = KeyCode.W;
    [SerializeField] private KeyCode downKey  = KeyCode.S;
    [SerializeField] private KeyCode leftKey  = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    private void Update()
    {
        up    = Input.GetKeyDown(upKey);
        down  = Input.GetKeyDown(downKey);
        left  = Input.GetKeyDown(leftKey);
        right = Input.GetKeyDown(rightKey);
    }
}
