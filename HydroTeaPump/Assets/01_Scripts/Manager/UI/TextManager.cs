using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();//텍스트들이 저장될

    private void Awake()
    {
        GenerateData();
    }

    private void GenerateData()
    {
        //대사 추가 예시 [좌측 : ID, 우측 : 대사]
        talkData.Add(1, new string[] { "날개꽃은 잘 잡고있지 않으면 날아가니까 꼭 붙잡고 있어야 해.","이 꽃은 날개가 없는 걸 가볍게 만들지만 날개가 있는 걸 무겁게 만들어.","이거? 아무래도 안개나비보단 무겁지만, 별조각보다 가벼워." });
        talkData.Add(2, new string[] { "사과 하나 먹겠다고 산을 오르는 건 역시 무리같다고 느끼지만... \n그래도 겸사겸사 재료도 수집할 수 있으니까 뭐 괜찮다고 생각해.","마법에 사용하는 별무리조각은 사과 한개 무개가 아니면 안돼.\n음... 이 정도 무개야. " });
        talkData.Add(3, new string[] { "찾기 진짜 힘드네! 늑대가 펑펑 우는 일은 거의 없으니까 그러려나...","늑대눈물은 이 나라에서 구할 수 있는 재료중에 가장 무거워. 물 밖에 나온 인어비늘이랑 같은 무게야.","그러고 보니 날개꽃이랑 달진주도 무개가 같았지" });
        talkData.Add(4, new string[] { "달을 보면 흉폭하게 변하는 늑대족 얘기 기억나니?","늑대눈물은 달빛을 보면 깜짝 놀라서 안에 모아뒀던 마나를 전부 흘려버려.","그러니까 진주는 평소에 천을 덮어서 늑대눈물과 먼 곳에 보관할 것."});
        talkData.Add(5, new string[] { "잡기도 힘든데 연약하기까지 하니까 다른 재료보다 훨씬 조심해서 만져야 해.","안개나비는 말 그대로 안개라서, 아무 무개가 없어.","들고있는 느낌조차 안나니까 정말 조심해야 해!"});
        talkData.Add(6, new string[] { "마도서에 있는 재료들 중엔 더이상 구할 수 없는 재료도 있지.","아애 구할 수 조차 없는 재료들도 가끔 적혀있어.","기억해둬, 인어는 비늘을 떨어뜨리지 않아... ","꼭 기억해서 나처럼 속지 말아야 해. 알았지?"});
    }

    public string GetTalk(int id, int talkIndex) //다른 스크립트에서 대사를 불러와야 한다면 이 함수 사용, id와 몇번째 대사인지.
    {
        if(talkData.ContainsKey(id))
        {
            if (talkIndex == talkData[id].Length)
            {
                return null;
            }
            return talkData[id][talkIndex];
        }
        return null;
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
