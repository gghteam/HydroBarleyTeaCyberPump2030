using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPopupOpen = false;

    private bool[] stageClear = new bool[5]; // 스테이지 클리어 정보 배열

    public bool[] GetStageClearStat()
    {
        return stageClear;
    }

    // 데이터 저장 용
    private void OnDestroy()
    {
        DataVO vo = new DataVO("stageStat", JsonUtility.ToJson(new StageVO(stageClear)));
        SaveManager.SaveOption(vo, "stageStat.json");
    }

    [Header("카메라")]
    private CinemachineImpulseSource ImpulseSource;

    public int currentStage;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        if (GameObject.Find("Vcam") != null)
            ImpulseSource = GameObject.Find("Vcam").GetComponent<CinemachineImpulseSource>();
    }

    /// <summary>
    /// 주어진 값만큼 카메라 흔드는 함수
    /// </summary>
    /// <param name="force">흔드는 힘</param>
    public void CameraShaking(float force)
    {
        ImpulseSource.GenerateImpulse(force);
    }
}
