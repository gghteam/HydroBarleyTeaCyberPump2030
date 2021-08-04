using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RythmPlayerMove : GeneralMove
{
    private Animator          animator;
    private RhythmPlayerInput input; // 입력

    public NoteManager noteManager;

    [SerializeField] private GameObject[] hps = new GameObject[9];

    public int playerHp = 9;

    [SerializeField]
    private RythmTutorial tutorial = null;
    private void Start()
    {
        animator = GetComponent<Animator>();
        input    = GetComponent<RhythmPlayerInput>();
    }
    /// <summary>
    /// 플레이어 이동함수
    /// </summary>
    public void PlayerMoving()
    {
        float h = input.right ? 1 : (input.left ? -1 : 0);
        float v = input.up ? 1    : (input.down ? -1 : 0);
        if (h != 0)
        {
            v = 0;
        }

        isMoving = true;

        Vector3 dir = new Vector3(h, v, 0); // 1, 0, -1 : h, v
        transform.localScale = new Vector3(h!=0? -h/2:transform.localScale.x, 0.5f, 1);
        Moving(dir);
    }

    private void Update()
    {
        animator.SetBool("Run", isMoving);

        SetHP();
    }

    private void SetHP()
    {
        for (int i = 0; i < hps.Length; ++i)
        {
            hps[i].SetActive(false);
        }

        for (int i = 0; i < playerHp; ++i)
        {
            hps[i].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 11)  //목표물과 접촉했을때
        {
            Debug.Log("ㅘ! 획득!");
            noteManager.canAct = false;
            GameSave.Instance.data.isClear = true;
            SceneLoadManager.LoadSceneAdditive("RewardScene");
        }
        else if(col.gameObject.layer == 12)//가시
        {
            Debug.Log("아 따가!");
            --playerHp;
            if(playerHp <=0)
            {
                noteManager.TimeOut();
                GameSave.Instance.data.isStory = false;
                GameSave.Instance.data.isClear = false;
                //SceneLoadManager.LoadScene("CutSceneScene");
            }
        }
        else if(col.gameObject.layer == 13)//튜토리얼
        {
            tutorial.TutorialPopUp(col.gameObject.GetComponent<RythmTutorialHelper>().tutorialIndex);
        }
    }

    
}
