using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] StagePrefabs;

    private void Start()
    {
        Instantiate(StagePrefabs[GameManager.Instance.currentStage]);
    }
}
