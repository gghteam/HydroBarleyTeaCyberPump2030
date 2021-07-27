using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPopupOpen = false;

    private bool[] stageClear = new bool[5]; // �������� Ŭ���� ���� �迭

    public bool[] GetStageClearStat()
    {
        return stageClear;
    }

    // ������ ���� ��
    private void OnDestroy()
    {
        DataVO vo = new DataVO("stageStat", JsonUtility.ToJson(new StageVO(stageClear)));
        SaveManager.SaveOption(vo, "stageStat.json");
    }

    [Header("ī�޶�")]
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
    /// �־��� ����ŭ ī�޶� ���� �Լ�
    /// </summary>
    /// <param name="force">���� ��</param>
    public void CameraShaking(float force)
    {
        ImpulseSource.GenerateImpulse(force);
    }
}
