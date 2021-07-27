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
    Vector3 firstPosition;
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
