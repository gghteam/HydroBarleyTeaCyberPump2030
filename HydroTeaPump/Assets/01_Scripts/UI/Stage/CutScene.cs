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

    [SerializeField]
    private Sprite[] cutSceneSprites = new Sprite[37];

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
        RefreshIndex();
        PopPop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PopPop(callbackSave);
            //Debug.Log(explainIndex);
        }
    }

    public void RefreshIndex()
    {
        //Debug.Log("ss");
        switch (GameManager.Instance.cutSceneState)
        {
            case GameManager.CutSceneState.Start:
                GameManager.Instance.spriteIndex = 0;
                explainId = 300;
                break;
            case GameManager.CutSceneState.Fail:
                GameManager.Instance.spriteIndex = 37;
                explainId = 100;
                break;
            case GameManager.CutSceneState.StageClear:
                GameManager.Instance.spriteIndex = 0;
                explainId = GameManager.Instance.currentStage +1;
                Debug.Log(explainId);
                break;
            case GameManager.CutSceneState.HappyEnding:
                GameManager.Instance.spriteIndex = 16;
                explainId = 400;
                break;
            case GameManager.CutSceneState.NormalEnding:
                GameManager.Instance.spriteIndex = 26;
                explainId = 401;
                break;
        }
        /*if (GameSave.Instance.data.isStory)
        {
            explainId = 300;
            GameManager.Instance.spriteIndex = 0;
        }
        else if (GameSave.Instance.data.isEnding)
        {
            explainId = GameSave.Instance.data.isGoodEnding ? 400 : 401;
            GameManager.Instance.spriteIndex = GameSave.Instance.data.isGoodEnding ? 16 : 26;
        }
        else
        {
            explainId = GameSave.Instance.data.isClear ? 13 : 100;
            GameManager.Instance.spriteIndex = GameSave.Instance.data.isClear ? 0 : 37;
        }*/
        explainIndex = 0;
        //Debug.Log(GameManager.Instance.spriteIndex);
    }
    public void PopPop(CutsceneEndCallback callback = null)
    {
        if (isPlaying) return;
        isPlaying = true;

        Talk(explainText, explainId, explainIndex);
    }
    private void Talk(UnityEngine.UI.Text text, int id, int talkIndex, CutsceneEndCallback callback = null) //대사 사용 예시 함수 대사가 계속 나온다면 딴 스크립트에서 이러케 쓰면 편함
    {
        string talkData = textManager?.GetTalk(id, talkIndex);
        //if (GameManager.Instance.spriteIndex == 13) SceneLoadManager.UnLoadScene("CutSceneScene");

        string nextTalkData = textManager?.GetTalk(id, talkIndex+1);
        string nextTalkId = textManager?.GetTalk(id+1, 0);

        if (talkData != null)
        {
            text.text = talkData;
            PopUp();
            explainIndex++;
            GameManager.Instance.spriteIndex++;
        }
        else
        {
            if (GameSave.Instance.data.isStory || GameSave.Instance.data.isEnding)
            {
                if (!GameSave.Instance.data.isGoodEnding)
                {
                    GameManager.Instance.stageClear[0] = false;
                    GameManager.Instance.stageClear[1] = false;
                    GameManager.Instance.stageClear[2] = true;
                    GameManager.Instance.stageClear[3] = true;
                    GameManager.Instance.stageClear[4] = false;
                }

                SceneLoadManager.UnLoadScene("CutSceneScene");
            }
            else
            {
                //씬 전환
                if (GameSave.Instance.data.isClear)
                {
                    GameSave.Instance.data.isClear = false;
                    GameManager.Instance.stageClear[GameManager.Instance.currentStage] = true;

                    GameManager.Instance.SaveClearData();

                    SceneLoadManager.LoadScene("MainMenu");
                }
                else
                {
                    //어느 씬을 로드할지 결정
                    callbackSave?.Invoke();
                }
            }

        }
        if (nextTalkData == null && nextTalkId != null)
        {
            explainId++;
            explainIndex = 0;
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

        //Debug.Log(GameManager.Instance.spriteIndex);
        //Debug.Log(cutSceneSprites.Length);
        transform.GetChild(2).GetComponent<Image>().sprite = cutSceneSprites[GameManager.Instance.spriteIndex];
        seq.Join(transform.GetChild(2).GetComponent<Image>().DOFade(1, .2f).SetDelay(.3f));

        //텍스트
        transform.GetChild(3).localScale -= transform.localScale / 2;
        seq.Join(transform.GetChild(3).GetComponent<Text>().DOFade(1, 1f));
        seq.Join(transform.GetChild(3).DOScale(prevTextScale, .4f).SetEase(Ease.OutBack));

        seq.OnComplete(() => { isPlaying = false;/*Debug.Log("sss");*/ });
    }
    private void SetChildAlpha()
    {
        transform.GetChild(2).GetComponent<Image>().color = new Color(1,1,1,0) ;
        transform.GetChild(3).GetComponent<Text>().color = new Color(1,1,1,0) ;
    }
}
