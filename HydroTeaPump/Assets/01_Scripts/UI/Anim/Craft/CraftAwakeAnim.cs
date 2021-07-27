using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CraftAwakeAnim : MonoBehaviour
{
    [Header("원본과 목표 위치")]
    [SerializeField] private Transform origin;
    [SerializeField] private Transform target;

    [Header("움직일 시간")]
    [SerializeField] private float duration;

    [SerializeField] private CharactorUI charAnim;

    void Start()
    {
        transform.position = origin.position;

        transform.DOMove(target.position, duration).SetEase(Ease.OutCubic).OnComplete(() => StartCoroutine(charAnim.Animation()));
    }

}
