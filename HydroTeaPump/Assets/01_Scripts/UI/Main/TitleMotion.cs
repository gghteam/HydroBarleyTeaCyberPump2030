using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TitleMotion : MonoBehaviour
{
    [SerializeField]
    private Transform titlePanel = null;
    public Transform lastPos;
    Vector3 firstPosition;

    /*delegate 반환형 변수명(매개변수);
    (변수명 변수);*/
    private bool isPanelEnable = true;
    void Start()
    {
        firstPosition = titlePanel.position;
        titlePanel.position = lastPos.position;
        TitlePanelMove(true,2);
    }

    void Update()
    {
        if(Input.anyKey)
        {
            TitlePanelMove(false,1);
        }
    }

    public void TitlePanelMove(bool enable,float time)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(titlePanel.DOMove(enable ? firstPosition:lastPos.position, time));
        seq.Join(titlePanel.GetComponent<Image>().DOFade(enable? 1:0, time));
    }
}
