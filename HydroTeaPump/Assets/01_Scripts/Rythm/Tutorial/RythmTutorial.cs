using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmTutorial : MonoBehaviour
{
    //텍스트 매니저에 아이디 추가 후 튜토리얼 내용 작성

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
    private void Talk(UnityEngine.UI.Text text, int id, int talkIndex) //대사 사용 예시 함수 대사가 계속 나온다면 딴 스크립트에서 이러케 쓰면 편함
    {
        string talkData = textManager.GetTalk(id, talkIndex);
        string nextTalkData = textManager.GetTalk(id, talkIndex +1);

        //텍스트 리셋한번

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
