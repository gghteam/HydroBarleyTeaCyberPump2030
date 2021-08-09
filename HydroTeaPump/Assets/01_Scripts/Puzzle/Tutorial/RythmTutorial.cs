using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmTutorial : MonoBehaviour
{
    //�ؽ�Ʈ �Ŵ����� ���̵� �߰� �� Ʃ�丮�� ���� �ۼ�

    [SerializeField]
    private Transform talkPanel = null;
    [SerializeField]
    private Text talkText = null;
    [SerializeField]
    private TextManager textManager = null;
    [SerializeField]
    private NoteManager noteManager = null;
    private void Start()
    {
        talkPanel.gameObject.SetActive(false);
    }
    public void TutorialPopUp(int index)
    {
        talkPanel.gameObject.SetActive(true);
        noteManager.canAct = false;
        Talk(talkText,index + 200,0);
    }
    private void Talk(UnityEngine.UI.Text text, int id, int talkIndex) //��� ��� ���� �Լ� ��簡 ��� ���´ٸ� �� ��ũ��Ʈ���� �̷��� ���� ����
    {
        string talkData = textManager.GetTalk(id, talkIndex);
        string nextTalkData = textManager.GetTalk(id, talkIndex +1);

        //�ؽ�Ʈ �����ѹ�

        if (talkData != null)
        {
            int leng;
            text.DOText(talkData, leng = talkData.Length > 3 ? talkData.Length / 5 : talkData.Length).SetId("Talk").OnComplete(() =>
            {
                if(nextTalkData == null)
                {
                    noteManager.canAct = true;
                }
                else
                {
                    Talk(text, id, ++talkIndex);
                }

            });
        }
    }
}
