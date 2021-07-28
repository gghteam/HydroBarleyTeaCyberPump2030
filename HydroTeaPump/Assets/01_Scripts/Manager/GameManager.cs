using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPopupOpen = false;

    public bool[] stageClear = new bool[5]; // 스테이지 클리어 정보 배열

    public bool isClear = false;
    public bool isStory = true;
    public bool isEnding = false;
    public bool isGoodEnding = false;

    public bool storyWatched = false;

    public bool[] GetStageClearStat()
    {
        SetClearData();
        return stageClear;
    }
    #region 데이터 저장 용

    // 데이터 저장 용
    private void OnDestroy()
    {
        SaveClearData();
    }
    public void SaveClearData()
    {
        DataVO vo = new DataVO("stageStat", JsonUtility.ToJson(new StageVO(stageClear)));
        SaveManager.SaveOption(vo, "/stageStat.json");
    }
    public void SetClearData()
    {
        DataVO vo = SaveManager.LoadSavedOption("/stageStat.json");
        if (vo == null)
        {
            stageClear[0] = false;
            stageClear[1] = false;
            stageClear[2] = true;
            stageClear[3] = true;
            stageClear[4] = false;

            return;
        }


        StageVO stage = JsonUtility.FromJson<StageVO>(vo.payload);
        
        // 클리어 정보 넣어줌
        for (int i = 0; i < stageClear.Length; ++i)
        {
            stageClear[i] = stage.stageClearStatus[i];
        }
    }
    #endregion

    [Header("카메라")]
    private CinemachineImpulseSource ImpulseSource;

    public int currentStage;
    private void Awake()
    {
        if (Instance != null) return;
        Instance = this;
        DontDestroyOnLoad(this);

        if (isStory && !storyWatched)
        {
            storyWatched = true;
            SceneLoadManager.LoadSceneAdditive("CutSceneScene");
        }
    }
    private void Start()
    {
        if (GameObject.Find("Vcam") != null)
            ImpulseSource = GameObject.Find("Vcam").GetComponent<CinemachineImpulseSource>();

        SetClearData();

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