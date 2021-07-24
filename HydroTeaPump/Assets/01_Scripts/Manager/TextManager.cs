using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private Dictionary<int, string[]> talkData; //텍스트들이 저장될

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    private void GenerateData()
    {
        //대사 추가 예시 [좌측 : ID, 우측 : 대사]
        talkData.Add(1, new string[] { "그 치킨 좀 줘봐", "그런데 말이야", "이", "치킨이란게 참 신기해", "나때는 이런 그... 뭐냐 크런키?", "그런게 없었거든", "몇개인지 말 안했다고?", "지금 나 늙었다고 무시 하는거야?", "허,참 어이가 없어서", "니가 두발로 걷기 시작할때 말이야", "나는 고오생을 하고 있었어요" });
    }

    public string GetTalk(int id, int talkIndex) //다른 스크립트에서 대사를 불러와야 한다면 이 함수 사용, id와 몇번째 대사인지.
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        return talkData[id][talkIndex];
    } 

   /* private void Talk(UnityEngine.UI.Text text, int id, int talkIndex) //대사 사용 예시 함수 대사가 계속 나온다면 딴 스크립트에서 이러케 쓰면 편함
    {
        string talkData = textManager.GetTalk(id, talkIndex);

        //텍스트 리셋한번

        if (talkData != null)
        {
            int leng;
            text.DOText(talkData, leng = talkData.Length > 3 ? talkData.Length / 5 : talkData.Length).SetId("Talk").OnComplete(() =>
            {
                Talk(text, id, ++talkIndex);
            });
        }
    }*/
}
