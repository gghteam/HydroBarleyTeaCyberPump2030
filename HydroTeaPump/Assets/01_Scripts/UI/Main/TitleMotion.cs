using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TitleMotion : MonoBehaviour
{
    [SerializeField]
    private Transform titlePanel;
    public Transform lastPos;
    void Start()
    {
        Vector3 firstPosition = titlePanel.position;
        titlePanel.position = lastPos.position;
        Sequence seq = DOTween.Sequence();
        seq.Append(titlePanel.DOMove(firstPosition, 2f));
        seq.Join(titlePanel.GetComponent<Image>().DOFade(1,2));
        seq.SetDelay(2);
        seq.SetLoops(2,LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
