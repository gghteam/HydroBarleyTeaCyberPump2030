using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    static CutScene inst = null;
    
    private bool isPlaying = false;

    private TextManager textManager;

    private Text explainText;

    private int explainId;
    private int explainIndex;

    public delegate void CutsceneEndCallback();

    private CutsceneEndCallback callbackSave = null;
    static public void SetCallback(CutsceneEndCallback callback)
    {
        inst.callbackSave = callback;
    }

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        explainText = transform.GetChild(3).GetComponent<Text>();

        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();

        explainId = 1;
        explainIndex = 0;
        PopPop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PopPop(callbackSave);
        }
    }

    public void PopPop(CutsceneEndCallback callback = null)
    {
        if (isPlaying) return;
        isPlaying = true;

        Talk(explainText, explainId, explainIndex);
        explainIndex++;
    }
    private void Talk(UnityEngine.UI.Text text, int id, int talkIndex, CutsceneEndCallback callback = null) //대사 사용 예시 함수 대사가 계속 나온다면 딴 스크립트에서 이러케 쓰면 편함
    {
        string talkData = textManager.GetTalk(id, talkIndex);

        if (talkData != null)
        {
            text.text = talkData;
            PopUp();
        }
        else
        {
            

            //씬 전환
            if(GameManager.Instance.isClear)
            {
                GameManager.Instance.isClear = false;
                GameManager.Instance.stageClear[GameManager.Instance.currentStage] = true;
                SceneLoadManager.LoadScene("MainMenu");
            }
            else
            {
                //어느 씬을 로드할지 결정
                callbackSave?.Invoke();
            }
        }
    }
    private void PopUp(CutsceneEndCallback callback = null)
    {
        gameObject.SetActive(true);
        SetChildAlpha();
        Vector3 prevScale = transform.GetChild(1).localScale;
        Vector3 prevTextScale = transform.GetChild(3).localScale;

        Sequence seq = DOTween.Sequence();
        //뒷 이미지
        transform.GetChild(1).localScale -= transform.localScale / 2;
        seq.Append(transform.GetChild(1).DOScale(prevScale, .5f).SetEase(Ease.OutBack));
        //설명 이미지
        seq.Join(transform.GetChild(2).GetComponent<Image>().DOFade(1, .2f).SetDelay(.3f));

        //텍스트
        transform.GetChild(3).localScale -= transform.localScale / 2;
        seq.Join(transform.GetChild(3).GetComponent<Text>().DOFade(1, 1f));
        seq.Join(transform.GetChild(3).DOScale(prevTextScale, .4f).SetEase(Ease.OutBack));

        seq.OnComplete(() => { isPlaying = false; });
    }
    private void SetChildAlpha()
    {
        transform.GetChild(2).GetComponent<Image>().color = new Color(1,1,1,0) ;
        transform.GetChild(3).GetComponent<Text>().color = new Color(1,1,1,0) ;
    }
}
