using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    private bool isPlaying = false;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void PopPop()
    {
        if (isPlaying) return;
        isPlaying = true;
        gameObject.SetActive(true);
        SetChildAlpha();
        Vector3 prevScale = transform.GetChild(0).localScale;
        Vector3 prevTextScale = transform.GetChild(2).localScale;

        Sequence seq = DOTween.Sequence();
        //뒷 이미지
        transform.GetChild(0).localScale -= transform.localScale / 2;
        seq.Append(transform.GetChild(0).DOScale(prevScale, .5f).SetEase(Ease.OutBack));
        //설명 이미지
        seq.Join(transform.GetChild(1).GetComponent<Image>().DOFade(1, .2f).SetDelay(.3f));

        //텍스트
        transform.GetChild(2).localScale -= transform.localScale / 2;
        seq.Join(transform.GetChild(2).GetComponent<Text>().DOFade(1, 1f));
        seq.Join(transform.GetChild(2).DOScale(prevTextScale, .4f).SetEase(Ease.OutBack));

        seq.OnComplete(()=> { isPlaying = false; });
    }

    private void SetChildAlpha()
    {
        transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0) ;
        transform.GetChild(2).GetComponent<Text>().color = new Color(1,1,1,0) ;
    }
}
