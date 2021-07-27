using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailedUI : MonoBehaviour
{
    private bool[] createInfo = new bool[3];

    [SerializeField] private Text reasonText = null;


    private void Start()
    {
        createInfo = FailedManager.GetSuccessInfo();
    }

    /// <summary>
    /// 성공한 재료를 올림
    /// </summary>
    public void SetText()
    {
        reasonText.text = $"올바른 재료: {(createInfo[0] ? "별무리조각 " : "")}별{(createInfo[1] ? "늑대눈물 " : "")} , {(createInfo[2] ? "안개나비" : "")}";
    }

}
