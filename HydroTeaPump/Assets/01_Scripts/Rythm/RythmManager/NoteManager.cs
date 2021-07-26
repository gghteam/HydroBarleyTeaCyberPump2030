using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class NoteManager : MonoBehaviour
{


    public GameObject notePrefab;

    public int bpm = 0;
    double currentTime = 0d;

    // 노트 프리팹 생성 및 리스트 저장.
    public List<GameObject> noteObj_Line = new List<GameObject>();


    [SerializeField]
    Transform tfNoteAppear = null;
    [SerializeField]
    Transform Center = null;
    [SerializeField]
    RectTransform[] timingRect = null;

    Vector2[] timingBoxes = null;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

        //타이밍 박스 설정
        timingBoxes = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxes[i].Set(Center.localPosition.y + timingRect[i].rect.height / 2,
                               Center.localPosition.y - timingRect[i].rect.height / 2);
        }
        
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        
        if(currentTime >= 60d/ bpm)
        {
            GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
            t_note.transform.position = tfNoteAppear.position;
            t_note.SetActive(true);
            noteObj_Line.Add(t_note);
            currentTime -= 60d / bpm;
            enemy.GetComponent<EnemyMove>().EnemyMoving();
        }
        
        if(Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            CheckTiming(noteObj_Line);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            RemoveNoteObj(collision.gameObject);
        }
    }


    /// <summary>
    /// 노트 제거 함수
    /// </summary>
    /// <param name="a">제거할 노트</param>
    public void RemoveNoteObj(GameObject a)
    {
        noteObj_Line.Remove(a);

        ObjectPool.instance.noteQueue.Enqueue(a);
        a.SetActive(false);
    }

    /// <summary>
    /// 노트 판정 함수
    /// </summary>
    /// <param name="a"></param>
    public void CheckTiming(List<GameObject> a)
    {
        for (int i = 0; i < a.Count; i++)
        {
            float t_notePosY = a[i].transform.localPosition.y;

            for (int x = 0; x < timingBoxes.Length; x++)
            {
                if (timingBoxes[x].y <= t_notePosY && timingBoxes[x].x >= t_notePosY)
                {
                    a[i].GetComponent<Note>().HideNote();
                    a.RemoveAt(i);
                    Debug.Log("Hit" + x);
                    if(x <= 2)
                    {
                        player.GetComponent<StagePlayerMove>().PlayerMoving();
                    }
                    return;
                }
            }
            Debug.Log("Miss");
            GameManager.Instance.CameraShaking(1f);
        }
        /*Debug.Log(timingBoxes[0].y);
        Debug.Log(timingBoxes[0].x);
        Debug.Log(a[0].transform.localPosition.y);*/
    }
}
