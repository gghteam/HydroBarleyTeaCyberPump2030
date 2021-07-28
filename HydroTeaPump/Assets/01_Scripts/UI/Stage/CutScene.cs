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

    private int spriteIndex = 0;

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
            Debug.Log(explainIndex);
        }
    }

    public void RefreshIndex()
    {

        if (GameManager.Instance.isStory)
        {
            explainId = 300;
            spriteIndex = 0;
        }
        else if (GameManager.Instance.isEnding)
        {
            explainId = GameManager.Instance.isGoodEnding ? 400 : 401;
            spriteIndex = GameManager.Instance.isGoodEnding ? 16 : 26;
        }
        else
        {
            explainId = GameManager.Instance.isClear ? 13 : 100;
            spriteIndex = GameManager.Instance.isClear ? 0 : 37;
        }
        explainIndex = 0;

    }
    public void PopPop(CutsceneEndCallback callback = null)
    {
        if (isPlaying) return;
        isPlaying = true;

        Talk(explainText, explainId, explainIndex);
    }
    private void Talk(UnityEngine.UI.Text text, int id, int talkIndex, CutsceneEndCallback callback = null) //��� ��� ���� �Լ� ��簡 ��� ���´ٸ� �� ��ũ��Ʈ���� �̷��� ���� ����
    {
        string talkData = textManager.GetTalk(id, talkIndex);
        if (spriteIndex == 13) SceneLoadManager.UnLoadScene("CutSceneScene");

        string nextTalkData = textManager.GetTalk(id, talkIndex+1);
        string nextTalkId = textManager.GetTalk(id+1, 0);

        if (talkData != null)
        {
            text.text = talkData;
            PopUp();
            explainIndex++;
            spriteIndex++;
        }
        else
        {
            if (GameManager.Instance.isStory || GameManager.Instance.isEnding)
            {
                if (!GameManager.Instance.isGoodEnding)
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
                //�� ��ȯ
                if (GameManager.Instance.isClear)
                {
                    GameManager.Instance.isClear = false;
                    GameManager.Instance.stageClear[GameManager.Instance.currentStage] = true;

                    GameManager.Instance.SaveClearData();

                    SceneLoadManager.LoadScene("MainMenu");
                }
                else
                {
                    //��� ���� �ε����� ����
                    callbackSave?.Invoke();
                }
            }

        }
        if(!GameManager.Instance.isEnding)
        {
            if (nextTalkData == null && nextTalkId != null)
            {
                explainId++;
                explainIndex = 0;
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
        //�� �̹���
        transform.GetChild(1).localScale -= transform.localScale / 2;
        seq.Append(transform.GetChild(1).DOScale(prevScale, .5f).SetEase(Ease.OutBack));
        //���� �̹���

        Debug.Log(spriteIndex);
        Debug.Log(cutSceneSprites.Length);
        transform.GetChild(2).GetComponent<Image>().sprite = cutSceneSprites[spriteIndex];
        seq.Join(transform.GetChild(2).GetComponent<Image>().DOFade(1, .2f).SetDelay(.3f));

        //�ؽ�Ʈ
        transform.GetChild(3).localScale -= transform.localScale / 2;
        seq.Join(transform.GetChild(3).GetComponent<Text>().DOFade(1, 1f));
        seq.Join(transform.GetChild(3).DOScale(prevTextScale, .4f).SetEase(Ease.OutBack));

        seq.OnComplete(() => { isPlaying = false;Debug.Log("sss"); });
    }
    private void SetChildAlpha()
    {
        transform.GetChild(2).GetComponent<Image>().color = new Color(1,1,1,0) ;
        transform.GetChild(3).GetComponent<Text>().color = new Color(1,1,1,0) ;
    }
}
