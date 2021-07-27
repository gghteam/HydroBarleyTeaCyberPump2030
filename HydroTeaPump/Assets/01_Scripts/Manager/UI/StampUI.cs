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
        if (stageClear == null) // 게임메니저에 정보가 없다면
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

            // 클리어 정보 넣어줌
            for (int i = 0; i < stageClear.Length; ++i)
            {
                stageClear[i] = stage.stageClearStatus[i];
            }
        }
        
        // 스템프 표시 설정
        for (int i = 0; i < stageClear.Length; ++i)
        {
            stamps[i].SetActive(stageClear[i]);
        }
    }
}