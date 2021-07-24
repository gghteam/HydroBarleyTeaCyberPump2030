using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private Dictionary<int, string[]> talkData; //�ؽ�Ʈ���� �����

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    private void GenerateData()
    {
        //��� �߰� ���� [���� : ID, ���� : ���]
        talkData.Add(1, new string[] { "�� ġŲ �� ���", "�׷��� ���̾�", "��", "ġŲ�̶��� �� �ű���", "������ �̷� ��... ���� ũ��Ű?", "�׷��� �����ŵ�", "����� �� ���ߴٰ�?", "���� �� �ľ��ٰ� ���� �ϴ°ž�?", "��,�� ���̰� ���", "�ϰ� �ι߷� �ȱ� �����Ҷ� ���̾�", "���� ������� �ϰ� �־����" });
    }

    public string GetTalk(int id, int talkIndex) //�ٸ� ��ũ��Ʈ���� ��縦 �ҷ��;� �Ѵٸ� �� �Լ� ���, id�� ���° �������.
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        return talkData[id][talkIndex];
    } 

   /* private void Talk(UnityEngine.UI.Text text, int id, int talkIndex) //��� ��� ���� �Լ� ��簡 ��� ���´ٸ� �� ��ũ��Ʈ���� �̷��� ���� ����
    {
        string talkData = textManager.GetTalk(id, talkIndex);

        //�ؽ�Ʈ �����ѹ�

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
