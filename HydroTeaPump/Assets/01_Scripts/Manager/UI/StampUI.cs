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
        if (stageClear == null) // ���Ӹ޴����� ������ ���ٸ�
        {
            DataVO vo = SaveManager.LoadSavedOption("stageStat.json");
            if (vo == null)
            {
                for (int i = 0; i < stageClear.Length; ++i)
                {
                    stageClear[i] = false;
                }
            }


            StageVO stage = JsonUtility.FromJson<StageVO>(vo.payload);

            // Ŭ���� ���� �־���
            for (int i = 0; i < stageClear.Length; ++i)
            {
                stageClear[i] = stage.stageClearStatus[i];
            }
        }
        
        // ������ ǥ�� ����
        for (int i = 0; i < stageClear.Length; ++i)
        {
            stamps[i].SetActive(stageClear[i]);
        }
    }
}