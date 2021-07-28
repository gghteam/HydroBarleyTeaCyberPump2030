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


        talkData.Add(100, new string[] { "\"채력이 부족해서 더이상 못 찾겠다냥....\"", "결국 돌아오고 말았습니다." });

        //튜토리얼
        talkData.Add(200, new string[] { "휴! 일단 여기서 별무리조각을 찾아야한다냥!","평소엔 집사가 안고서 데려다줘서 몰랐는데 엄청 넓다냥...", "빨리 조각 찾고 집사랑 같이 쉬고싶다냥.", "집사! 기다려라냥!" });
        talkData.Add(201, new string[] { "앞에 수풀이 있다냥...","이정도면 지나갈 수 있을것 같다냥!" });
        talkData.Add(202, new string[] { "이 정도 크기 나무면 밀 수 있다냥.", "집사 머그컵 미는 것 같아서 재밌다냥." });
        talkData.Add(203, new string[] { "엄청 큰 바위다냥! 밀어도 꼼짝 안한다냥..." });
        talkData.Add(204, new string[] { "냐냥!! 따끔하다냥! 가시는 가까이 가기도 싫다냥. 아프다냥..." });
        talkData.Add(205, new string[] { "앞에 슬라임이 있다냥!","공격은 안하지만...지나갈수없다냥!" });

        //초반 스토리
        talkData.Add(300, new string[] { "안냥! 네로다냥. \n세상 최고의 마녀의 유일무이한 사역마다냥" });
        talkData.Add(301, new string[] { "우리 집사는 엄청 대단한 마녀다냥. \n마법을 담은 물건을 도시로 나가 팔고온다냥!","우리 집사 솜씨가 좋아서 도구는 가져가면 금방 동난다냥!\n세상 그 어떤 마녀도 우리 집사보다 잘날 순 없다냥. "});
        talkData.Add(302, new string[] {" 아! 집사가 왔다냥! 집사 집사! 잘 갔다왔냥?","\"응. 잘 다녀왔어\"" });
        talkData.Add(303, new string[] { "\"하암... 너무너무 피곤해. 네로... 나 잠깐 눈좀 붙이고 있을게.\"" });
        talkData.Add(304, new string[] { "알았다냥!","알았다냥~","알았다냥..."});
        talkData.Add(305, new string[] { "...?" });
        talkData.Add(306, new string[] { "우리집사가눈을안뜬다냥!!!" });
        talkData.Add(307, new string[] { "틀림없이우리집사를질투한다른법사녀석짓이다냥!!","내가 우리집사... 반드시 고쳐주고 말거다냥!!!"});

        //엔딩
        talkData.Add(400, new string[] { "드디어 성공했다냥!", "내힘으로 주인을 고쳤다냥!", "주인이 일어났다냥!", "\"음...? 네로..? 마법진..? 피로회복 마법이잖아..\"", "주인 주인! 내가 주인을 살렸다냥!", "\"아...\"", "\"고마워, 네로가 생명의 은인이네~\"", "역시 세상 최고의 마녀의 유일무이한 사역마다냥!" });

        talkData.Add(401, new string[] { "어라라..?","실패한거냥..?","안된다냥...!","주인...일어나봐라냥!","\"Zzzz\"","....?","설마 자는거냥?","......","네로는 주인에게 실망했다냥!","흥!" });

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
