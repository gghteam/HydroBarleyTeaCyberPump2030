using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class StampUI : MonoBehaviour
{
    [SerializeField] private GameObject[] stamps      = new GameObject[5];
    [SerializeField] private GameObject[] stageImages = new GameObject[5];
                     private bool[]       stageClear;

    void Start()
    {
        stageClear = GameManager.Instance.GetStageClearStat();

        for (int i = 0; i < stageImages.Length; ++i)
        {
            stageImages[i].SetActive(false);
        }

        if (stageClear[0] == false)
        {
            for (int i = 1; i < stageImages.Length; ++i)
            {
                stageImages[i].SetActive(true);
            }
        }

        // ������ ǥ�� ����
        for (int i = 0; i < stageClear.Length; ++i)
        {
            stamps[i].SetActive(stageClear[i]);
            Debug.Log(stageClear[i] + " " + i);
        }
    }

}