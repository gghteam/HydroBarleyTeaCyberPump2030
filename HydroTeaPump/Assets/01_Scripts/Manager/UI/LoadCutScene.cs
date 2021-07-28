using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCutScene : MonoBehaviour
{
    [SerializeField] private GameObject endPannel;

    bool called = false;

    private void Start()
    {
        endPannel.SetActive(false);

        CutScene.SetCallback(() => { endPannel.SetActive(true); });
    }

    private void Update()
    {
        //if (called) return;
        //called = true;
        //cutscene.PopPop(() => { endPannel.SetActive(true); });
        
    }
}
