using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour, IDisable
{
    public bool IsEnabled { get; set; }

    public void Disable()
    {
        IsEnabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("wasans");
        Invoke(nameof(Disable), 0.5f);
    }
}
