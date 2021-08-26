using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmTutorial : MonoBehaviour
{
    private PuzzlePlayerInput input; // �Է�

    //�ؽ�Ʈ �Ŵ����� ���̵� �߰� �� Ʃ�丮�� ���� �ۼ�

    [SerializeField]
    private Transform talkPanel = null;
    [SerializeField]
    private Text talkText = null;
    [SerializeField]
    private TextManager textManager = null;
    [SerializeField]
    private PuzzleManager puzzleManager = null;

    private bool isDoText = false;
    private void Start()
    {
        talkPanel.gameObject.SetActive(false);
        input = GameObject.Find("Player").GetComponent<PuzzlePlayerInput>();
    }
    private void Update()
    {
        if (isDoText && input.right || input.left || input.up|| input.down)
        {
            
        }
    }
    public void TutorialPopUp(int index)
    {
        talkPanel.gameObject.SetActive(true);
        puzzleManager.canAct = false;
        Talk(talkText,index + 200,0);
    }
    private void ResetText(Text text)
    {
        text.text = "";
    }
    private void Talk(UnityEngine.UI.Text text, int id, int talkIndex) //��� ��� ���� �Լ� ��簡 ��� ���´ٸ� �� ��ũ��Ʈ���� �̷��� ���� ����
    {
        isDoText = true;
        string talkData = textManager.GetTalk(id, talkIndex);
        string nextTalkData = textManager.GetTalk(id, talkIndex +1);

        //�ؽ�Ʈ �����ѹ�
        ResetText(text);

        if (talkData != null)
        {
            int leng;
            text.DOText(talkData, leng = talkData.Length > 3 ? talkData.Length / 5 : talkData.Length).SetId("Talk").OnComplete(() =>
            {
                if(nextTalkData == null)
                {
                    puzzleManager.canAct = true;
                    talkPanel.gameObject.SetActive(false);
                    isDoText = false;
                    Destroy(gameObject);
                }
                else
                {
                    Talk(text, id, ++talkIndex);
                }

            });
        }
    }
}
