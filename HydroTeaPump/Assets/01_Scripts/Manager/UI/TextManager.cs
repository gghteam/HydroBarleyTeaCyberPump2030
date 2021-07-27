using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();//�ؽ�Ʈ���� �����

    private void Awake()
    {
        GenerateData();
    }

    private void GenerateData()
    {
        //��� �߰� ���� [���� : ID, ���� : ���]
        talkData.Add(1, new string[] { "�������� �� ������� ������ ���ư��ϱ� �� ����� �־�� ��.","�� ���� ������ ���� �� ������ �������� ������ �ִ� �� ���̰� �����.","�̰�? �ƹ����� �Ȱ����񺸴� ��������, ���������� ������." });
        talkData.Add(2, new string[] { "��� �ϳ� �԰ڴٰ� ���� ������ �� ���� �������ٰ� ��������... \n�׷��� ����� ��ᵵ ������ �� �����ϱ� �� �����ٰ� ������.","������ ����ϴ� ������������ ��� �Ѱ� ������ �ƴϸ� �ȵ�.\n��... �� ���� ������. " });
        talkData.Add(3, new string[] { "ã�� ��¥ �����! ���밡 ���� ��� ���� ���� �����ϱ� �׷�����...","���봫���� �� ���󿡼� ���� �� �ִ� ����߿� ���� ���ſ�. �� �ۿ� ���� �ξ����̶� ���� ���Ծ�.","�׷��� ���� �������̶� �����ֵ� ������ ������" });
        talkData.Add(4, new string[] { "���� ���� �����ϰ� ���ϴ� ������ ��� ��ﳪ��?","���봫���� �޺��� ���� ��¦ ��� �ȿ� ��Ƶ״� ������ ���� �������.","�׷��ϱ� ���ִ� ��ҿ� õ�� ��� ���봫���� �� ���� ������ ��."});
        talkData.Add(5, new string[] { "��⵵ ���絥 �����ϱ���� �ϴϱ� �ٸ� ��Ẹ�� �ξ� �����ؼ� ������ ��.","�Ȱ������ �� �״�� �Ȱ���, �ƹ� ������ ����.","����ִ� �������� �ȳ��ϱ� ���� �����ؾ� ��!"});
        talkData.Add(6, new string[] { "�������� �ִ� ���� �߿� ���̻� ���� �� ���� ��ᵵ ����.","�ƾ� ���� �� ���� ���� ���鵵 ���� �����־�.","����ص�, �ξ�� ����� ����߸��� �ʾ�... ","�� ����ؼ� ��ó�� ���� ���ƾ� ��. �˾���?"});
    }

    public string GetTalk(int id, int talkIndex) //�ٸ� ��ũ��Ʈ���� ��縦 �ҷ��;� �Ѵٸ� �� �Լ� ���, id�� ���° �������.
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
