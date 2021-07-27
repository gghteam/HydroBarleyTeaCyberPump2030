using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [Header("������")]
    [SerializeField] private List<GameObject> clouds = new List<GameObject>();

    private Queue<GameObject> pool = new Queue<GameObject>();

    private WaitForEndOfFrame wait = new WaitForEndOfFrame();

    [Header("���� ���� ��ġ")]
    [SerializeField] private Transform cloudStartPos = null;

    void Start()
    {
        for (int i = 0; i < clouds.Count * 4; ++i)
        {
            AddQueue();
        }

        StartCoroutine(DisplayCloud());

        SetCloud();
    }

    private GameObject AddQueue()
    {
        GameObject temp = Instantiate(clouds[Random.Range(0, clouds.Count - 1)], this.transform);
        temp.SetActive(false);
        pool.Enqueue(temp); // ������ ����
        return temp;
    }

    private void SetCloud()
    {
        GameObject temp;

        if (pool.Peek().activeSelf)
        {
            temp = AddQueue();
        }
        else
        {
            temp = pool.Dequeue();
        }

        // ������ Y��ǥ���� ������ ��

        Vector2 targetpos = cloudStartPos.position;
        targetpos.y = Random.Range(targetpos.y - 0.4f, targetpos.y + 4.0f);
        temp.transform.position = targetpos;


        // ���� ������ ��
        temp.SetActive(true);
    }


    IEnumerator DisplayCloud()
    {
        while (true)
        {
            float time = Time.time;
            float rndWait = Random.Range(7.0f, 12.0f);


            while (time + rndWait > Time.time) { yield return wait; } // �ð��� �� ������ ��ٸ�

            SetCloud();
        }
    }
}
