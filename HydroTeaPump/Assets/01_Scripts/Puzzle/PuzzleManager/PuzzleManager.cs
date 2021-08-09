using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    static private PuzzleManager inst; // static 함수 접근 용도

    // 입력 키
    private SettingsVO opt = new SettingsVO();
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Sprite[] heartSprites;
    public Image heartSprite;

    public bool canAct = true;

    public AudioManager audioManager = null;

    public StageFailedManager failedManager;


    /// <summary>
    /// 0 = Cool, 1 = Normal, 2 = Bad
    /// </summary>
    private enum HeartState
    {
        COOL = 0,
        NORMAL = 1,
        BAD = 2
    }
    private HeartState heartState = HeartState.NORMAL;

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        opt = OptionManager.GetSettings();
        audioManager.StartMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canAct) return;

        // 키 입력 시 타이밍 체크
        if (Input.GetKeyDown(opt.moveUp) || Input.GetKeyDown(opt.moveRight) || Input.GetKeyDown(opt.moveLeft) || Input.GetKeyDown(opt.moveDown))
        {
            enemy.GetComponent<EnemyMove>().EnemyMoving();
            player.GetComponent<PuzzlePlayerMove>().PlayerMoving();
            HeartSpriteRefresh();
        }
    }

    /// <summary>
    /// 상태에 따른 하트 스프라이트 변환 함수
    /// </summary>
    public void HeartSpriteRefresh()
    {
        heartSprite.sprite = heartSprites[(int)heartState];
    }

}
