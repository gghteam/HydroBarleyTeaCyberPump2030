using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("ī�޶�")]
    public CinemachineImpulseSource ImpulseSource;
    private void Awake()
    {
        Instance = this;
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
