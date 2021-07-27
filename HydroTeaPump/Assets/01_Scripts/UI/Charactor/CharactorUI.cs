using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharactorUI : MonoBehaviour
{
    [SerializeField] Transform leftWing;
    [SerializeField] Transform rightWing;
    [SerializeField] Transform body;

    [Header("움직일 위치와 시간")]
    [SerializeField] List<Transform> bodyMovement     = new List<Transform>();
    [SerializeField] List<float>     bodyTransitTime  = new List<float>();

    [SerializeField] List<Transform> lWingMovement    = new List<Transform>();
    [SerializeField] List<float>     lWingTransitTime = new List<float>();

    [SerializeField] List<Transform> rWingMovement    = new List<Transform>();
    [SerializeField] List<float>     rWingTransitTime = new List<float>();

    private int bodyidx  = 0;
    private int lWingidx = 0;
    private int rWingidx = 0;

    public IEnumerator Animation()
    {
        body.DOMove(bodyMovement[bodyidx].position, bodyTransitTime[bodyidx]).SetEase(Ease.OutCubic).OnComplete(() => ++bodyidx);
        yield return new WaitForSeconds(0.1f);
        leftWing.DORotateQuaternion(lWingMovement[lWingidx].rotation, lWingTransitTime[lWingidx]).SetEase(Ease.InOutSine).OnComplete(() => ++lWingidx);
        yield return new WaitForSeconds(0.1f);
        rightWing.DORotateQuaternion(rWingMovement[rWingidx].rotation, rWingTransitTime[rWingidx]).SetEase(Ease.InOutSine).OnComplete(() => ++rWingidx);
    }
}
