using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("카메라")]
    public CinemachineImpulseSource ImpulseSource;
    private void Awake()
    {
        Instance = this;
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
