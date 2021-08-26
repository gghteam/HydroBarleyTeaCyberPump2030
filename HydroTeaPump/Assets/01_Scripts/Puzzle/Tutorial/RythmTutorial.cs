using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmTutorial : MonoBehaviour
{
    private PuzzlePlayerInput input; // 입력

    //텍스트 매니저에 아이디 추가 후 튜토리얼 내용 작성

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
    private void Talk(UnityEngine.UI.Text text, int id, int talkIndex) //대사 사용 예시 함수 대사가 계속 나온다면 딴 스크립트에서 이러케 쓰면 편함
    {
        isDoText = true;
        string talkData = textManager.GetTalk(id, talkIndex);
        string nextTalkData = textManager.GetTalk(id, talkIndex +1);

        //텍스트 리셋한번
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
