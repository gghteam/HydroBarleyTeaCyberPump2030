using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCutScene : MonoBehaviour
{
    [SerializeField] private CutScene cutscene;

    bool called = false;

    private void Update()
    {
        if (called) return;
        called = true;
        cutscene.PopPop();
        
    }
}
