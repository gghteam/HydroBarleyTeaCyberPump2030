using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPopupOpen = false;

    public bool[] stageClear = new bool[5]; // 스테이지 클리어 정보 배열

    public int spriteIndex = 0;

    public enum CutSceneState
    {
        Start,
        Fail,
        StageClear,
        HappyEnding,
        NormalEnding
    }

    public CutSceneState cutSceneState = CutSceneState.Start;
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

    public int currentStage = 0;
    private void Awake()
    {
        if (Instance != null) return;
        Instance = this;
        DontDestroyOnLoad(this);

        if (GameSave.Instance.data.isStory && !GameSave.Instance.data.storyWatched)
        {
            GameSave.Instance.data.storyWatched = true;
            GameSave.Instance.SaveGameData();
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