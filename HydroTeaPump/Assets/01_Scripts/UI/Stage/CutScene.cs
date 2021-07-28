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
    private void Talk(UnityEngine.UI.Text text, int id, int talkIndex, CutsceneEndCallback callback = null) //��� ��� ���� �Լ� ��簡 ��� ���´ٸ� �� ��ũ��Ʈ���� �̷��� ���� ����
    {
        string talkData = textManager.GetTalk(id, talkIndex);

        if (talkData != null)
        {
            text.text = talkData;
            PopUp();
        }
        else
        {
            

            //�� ��ȯ
            if(GameManager.Instance.isClear)
            {
                GameManager.Instance.isClear = false;
                GameManager.Instance.stageClear[GameManager.Instance.currentStage] = true;
                SceneLoadManager.LoadScene("MainMenu");
            }
            else
            {
                //��� ���� �ε����� ����
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
        //�� �̹���
        transform.GetChild(1).localScale -= transform.localScale / 2;
        seq.Append(transform.GetChild(1).DOScale(prevScale, .5f).SetEase(Ease.OutBack));
        //���� �̹���
        seq.Join(transform.GetChild(2).GetComponent<Image>().DOFade(1, .2f).SetDelay(.3f));

        //�ؽ�Ʈ
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
