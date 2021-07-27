using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI.Management.Button;
using UI.Interactive.Button;

// TODO
/*
마우스 따라다니는거 없에야 함
 
*/

// UI 관련
public partial class Inventory : MonoBehaviour
{
    [Header("아이탬 Enum 과 순서가 같아야 함")]
    [SerializeField] private Sprite[]     sprites     = new Sprite[0];     // 일반   아이탬 스프라이트
    [SerializeField] private Sprite[]     usedsprites = new Sprite[0];     // 선택된 아이탬 스프라이트
    [SerializeField] private Button[]     btns        = new Button[0];     // 인벤토리 버튼들
    [SerializeField] private GameObject[] faders      = new GameObject[0]; // 아이탬 없을 시 어둡게 처리

    [Header("따라다니게 되는 오브젝트")]
    [SerializeField] private GameObject     followedObj;
                     private SpriteRenderer followedRenderer = null;
                     private bool           follow           = false; // 따라다니는지
                     private ItemVO         lastItem         = null;  // 따라다니고 있는 오브젝트

    private SettingsVO opt = new SettingsVO();

    static private Inventory inst; // static 함수 접근 용도


    private void Start()
    {
        Select.SelectFrom(btns);

        opt = OptionManager.GetSettings();

        inst = this;
        LinkFunctions();
        SetSprite();
        followedRenderer = followedObj.GetComponent<SpriteRenderer>();

        Select.SetKey(opt.moveRight, opt.moveLeft, opt.select);
    }

    private void Update()
    {
        //FollowCursor();
        Select.MoveNext();
        Select.MovePrev();
        Select.MoveSelect();
        SetItemImage();
    }

    private void SetItemImage()
    {
        int idx = Select.GetIndex();

        for (int i = 0; i < btns.Length; ++i)
        {
            btns[i].image.sprite = sprites[i];
        }

        if (idx < btns.Length)
        {
            btns[idx].image.sprite = usedsprites[idx];
        }
        
    }
}

public partial class Inventory : MonoBehaviour
{
    #region 버튼 관련

    /// <summary>
    /// 버튼에게 아이탬 스프라이트를 적용시킴
    /// </summary>
    private void SetSprite()
    {
        for (int i = 0; i < btns.Length; ++i)
        {
            faders[i].SetActive(InventoryBase.GetInventory().items[i].count == 0);
            ButtonManagement.SetImage(btns[i], sprites[i]);
        }
    }

    /// <summary>
    /// 버튼에게 아이탬 가져오는 기능을 검
    /// </summary>
    private void LinkFunctions()
    {
        for (int i = 0; i < btns.Length; ++i)
        {
            int idx = i;
            ButtonManagement.AddEvent(btns[i], () => { InventoryBase.TryGetItem((ItemEnum)idx, ref lastItem);  follow = lastItem == null ? false : true; });
        }
    }

    #endregion

    #region 아이탬 관련

    /// <summary>
    /// 아이템이 마우스를 따라가게 함
    /// </summary>
    private void FollowCursor()
    {
        followedObj.SetActive(follow);

        
        if (follow)
        {
            Vector3 targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetpos.z = 0;
            followedObj.transform.position = targetpos;
            followedRenderer.sprite = sprites[(int)lastItem.itemEnum];
        }
    }

    /// <summary>
    /// 현제 활성화된 아이탬을 가져옴
    /// </summary>
    static public ItemVO GetCurrentItem()
    {
        inst.follow = false;
        inst.lastItem.count = 0;
        inst.SetSprite();
        return inst.lastItem;
    }

    /// <summary>
    /// 아이탬 스프라이트를 가져옵니다.
    /// </summary>
    /// <param name="itemEnum"></param>
    /// <returns>sprites[itemEnum]</returns>
    static public Sprite GetItemSprite(ItemEnum itemEnum)
    {
        return inst.sprites[(int)itemEnum];
    }  
    
    /// <summary>
    /// 아웃라인이 있는 아이탬 스프라이트를 가져옵니다.
    /// </summary>
    /// <param name="itemEnum"></param>
    /// <returns></returns>
    static public Sprite GetUsedItemSprite(ItemEnum itemEnum)
    {
        return inst.usedsprites[(int)itemEnum];
    }

    /// <summary>
    /// 따라다니고 있는 상태인지 리턴합니다.
    /// </summary>
    /// <returns>true when following</returns>
    static public bool IsFollowing()
    {
        return inst.follow;
    }

    #endregion
}