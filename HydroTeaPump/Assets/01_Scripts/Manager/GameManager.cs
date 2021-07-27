using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPopupOpen = false;

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
