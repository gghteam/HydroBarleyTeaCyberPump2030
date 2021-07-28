using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AppearAnimation : MonoBehaviour
{
    [Header("�⺻ ��ǥ")]
    [SerializeField] private Transform origin;
    [Header("Ÿ�� ��ǥ")]
    [SerializeField] private Transform target;

    [Header("���ϸ��̼� ����")]
    [SerializeField] private float duration;

    [Header("Ű �ؽ�Ʈ")]
    [SerializeField] private Text        text = null;
    [SerializeField] private CanvasGroup cvs  = null;

    private SpriteRenderer spr = null;
    
    private bool isUp = false;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.DOFade(0, 0);
        cvs.DOFade(0, 0);
        transform.position = new Vector2(transform.position.x, origin.position.y);

    }

    private void FixedUpdate()
    {
        text.text = OptionManager.GetSettings(KeyMapEnum.select).ToString();
    }
    
    public void ToggleEnable()
    {   
        isUp = !isUp;

        spr.DOFade(isUp ? 1 : 0, duration);
        cvs.DOFade(isUp ? 1 : 0, duration);
        transform.DOMoveY(isUp ? target.position.y : origin.position.y, duration).SetEase(isUp ? Ease.OutCirc : Ease.InCirc);
    }
}
