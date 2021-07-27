using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public partial class NoteManager : MonoBehaviour
{
    static private NoteManager inst; // static 함수 접근 용도

    public GameObject notePrefab;

    private int baseBPM = 0; // 초기 bpm
    public int bpm = 0;
    double currentTime = 0d;

    // 노트 프리팹 생성 및 리스트 저장.
    public List<GameObject> noteObj_Line = new List<GameObject>();

    // 입력 키
    private SettingsVO opt = new SettingsVO();

    [SerializeField]
    Transform tfNoteAppearRight = null;
    [SerializeField]
    Transform tfNoteAppearLeft = null;

    [SerializeField]
    Transform Center = null;
    [SerializeField]
    RectTransform[] timingRect = null;

    Vector2[] timingBoxes = null;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Sprite[] heartSprites;
    public Image heartSprite;

    public bool canAct=true;

    /// <summary>
    /// 0 = Cool, 1 = Normal, 2 = Bad
    /// </summary>
    private enum HeartState
    {
        COOL = 0,
        NORMAL =1,
        BAD = 2
    }
    private HeartState heartState = HeartState.NORMAL;

    private void Awake()
    {
        inst = this;
        baseBPM = bpm; // 다시 원래대로 돌리기 위함
    }

    void Start()
    {
        if (GameObject.Find("Enemy") != null)
            enemy = GameObject.Find("Enemy");
        //타이밍 박스 설정
        timingBoxes = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxes[i].Set(Center.localPosition.x - timingRect[i].rect.height / 2,
                               Center.localPosition.x + timingRect[i].rect.height / 2);
        }
        
        // 옵션 세팅 가져옴
        opt = OptionManager.GetSettings();
    }
    private void Update()
    {
        if (!canAct) return;
        currentTime += Time.deltaTime;
        
        if(currentTime >= 60d/ bpm)
        {
            MakeNote(true);
            MakeNote(false);
        }
        
        // 키 입력 시 타이밍 체크
        if(Input.GetKeyDown(opt.moveUp) || Input.GetKeyDown(opt.moveRight) || Input.GetKeyDown(opt.moveLeft) || Input.GetKeyDown(opt.moveDown))
            CheckTiming();
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            RemoveNoteObj(collision.gameObject);
            if(collision.GetComponent<Note>().isRightNote && heartState != HeartState.COOL)
            {
                heartState = (HeartState)1;
                HeartSpriteRefresh();
            }
        }
    }

    /// <summary>
    /// 노트 생성 함수
    /// </summary>
    public void MakeNote(bool isRight)
    {
        GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
        t_note.transform.position = isRight?  tfNoteAppearRight.position : tfNoteAppearLeft.position;
        t_note.transform.rotation =Quaternion.Euler(0,0,90);
        t_note.transform.localScale = new Vector3(144, isRight ? -144 : 144, 144);
        t_note.GetComponent<Note>().isRightNote = !isRight;
        t_note.SetActive(true);
        noteObj_Line.Add(t_note);
        currentTime -= 60d / bpm;
        if(enemy != null)
        {
            enemy.GetComponent<EnemyMove>().EnemyMoving();
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
    public void CheckTiming()
    {
        for (int i = 0; i < noteObj_Line.Count; i++)
        {
            float t_notePosX = noteObj_Line[i].transform.localPosition.x;
            if(noteObj_Line[i].GetComponent<Note>().isRightNote)
            {
                for (int x = 0; x < timingBoxes.Length; x++)
                {
                    if (timingBoxes[x].x <= t_notePosX && timingBoxes[x].y >= t_notePosX)
                    {
                        noteObj_Line[i].GetComponent<Note>().HideNote();
                        noteObj_Line[i-1].GetComponent<Note>().HideNote();
                        noteObj_Line.RemoveAt(i);
                        noteObj_Line.RemoveAt(i-1);
                        Debug.Log("Hit" + x);

                        if (x <2)
                        {
                            player.GetComponent<RythmPlayerMove>().PlayerMoving();
                        }
                        heartState = (HeartState)x;
                        HeartSpriteRefresh();
                        return;
                    }
                }

                //GameManager.Instance.CameraShaking(1f);

            }

        }

        Debug.Log("Miss");
        heartState = HeartState.BAD;
        HeartSpriteRefresh();
        /*Debug.Log(timingBoxes[0].y);
        Debug.Log(timingBoxes[0].x);
        Debug.Log(a[0].transform.localPosition.y);*/
    }

    /// <summary>
    /// 상태에 따른 하트 스프라이트 변환 함수
    /// </summary>
    public void HeartSpriteRefresh()
    {
        heartSprite.sprite = heartSprites[(int)heartState];
    }

}