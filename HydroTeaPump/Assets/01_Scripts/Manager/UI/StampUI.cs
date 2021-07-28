using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class StampUI : MonoBehaviour
{
    [SerializeField] private GameObject[] stamps     = new GameObject[5];
                     private bool[]       stageClear;


    void Start()
    {
        stageClear = GameManager.Instance.GetStageClearStat();


        // ������ ǥ�� ����
        for (int i = 0; i < stageClear.Length; ++i)
        {
            stamps[i].SetActive(stageClear[i]);
            Debug.Log(stageClear[i] + " " + i);
        }
    }

}