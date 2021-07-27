using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPopupOpen = false;

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
