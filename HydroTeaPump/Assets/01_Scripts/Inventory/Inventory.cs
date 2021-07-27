using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI.Management.Button;
using UI.Interactive.Button;

// TODO
/*
���콺 ����ٴϴ°� ������ ��
 
*/

// UI ����
public partial class Inventory : MonoBehaviour
{
    [Header("������ Enum �� ������ ���ƾ� ��")]
    [SerializeField] private Sprite[]     sprites     = new Sprite[0];     // �Ϲ�   ������ ��������Ʈ
    [SerializeField] private Sprite[]     usedsprites = new Sprite[0];     // ���õ� ������ ��������Ʈ
    [SerializeField] private Button[]     btns        = new Button[0];     // �κ��丮 ��ư��
    [SerializeField] private GameObject[] faders      = new GameObject[0]; // ������ ���� �� ��Ӱ� ó��

    [Header("����ٴϰ� �Ǵ� ������Ʈ")]
    [SerializeField] private GameObject     followedObj;
                     private SpriteRenderer followedRenderer = null;
                     private bool           follow           = false; // ����ٴϴ���
                     private ItemVO         lastItem         = null;  // ����ٴϰ� �ִ� ������Ʈ

    private SettingsVO opt = new SettingsVO();

    static private Inventory inst; // static �Լ� ���� �뵵


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
    #region ��ư ����

    /// <summary>
    /// ��ư���� ������ ��������Ʈ�� �����Ŵ
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
    /// ��ư���� ������ �������� ����� ��
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

    #region ������ ����

    /// <summary>
    /// �������� ���콺�� ���󰡰� ��
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
    /// ���� Ȱ��ȭ�� �������� ������
    /// </summary>
    static public ItemVO GetCurrentItem()
    {
        inst.follow = false;
        inst.lastItem.count = 0;
        inst.SetSprite();
        return inst.lastItem;
    }

    /// <summary>
    /// ������ ��������Ʈ�� �����ɴϴ�.
    /// </summary>
    /// <param name="itemEnum"></param>
    /// <returns>sprites[itemEnum]</returns>
    static public Sprite GetItemSprite(ItemEnum itemEnum)
    {
        return inst.sprites[(int)itemEnum];
    }  
    
    /// <summary>
    /// �ƿ������� �ִ� ������ ��������Ʈ�� �����ɴϴ�.
    /// </summary>
    /// <param name="itemEnum"></param>
    /// <returns></returns>
    static public Sprite GetUsedItemSprite(ItemEnum itemEnum)
    {
        return inst.usedsprites[(int)itemEnum];
    }

    /// <summary>
    /// ����ٴϰ� �ִ� �������� �����մϴ�.
    /// </summary>
    /// <returns>true when following</returns>
    static public bool IsFollowing()
    {
        return inst.follow;
    }

    #endregion
}