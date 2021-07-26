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
    public void CameraShaking(float force)//주어진 값으로 카메라 흔드는 함수
    {
        ImpulseSource.GenerateImpulse(force);
    }
}
