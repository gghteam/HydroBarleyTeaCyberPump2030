using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI.Management.Button;



// UI ����
public partial class Inventory : MonoBehaviour
{
    [Header("������ Enum �� ������ ���ƾ� ��")]
    [SerializeField] private Sprite[] sprites = new Sprite[0]; // �����Ƶ�
    [SerializeField] private Button[] btns    = new Button[0]; // �κ��丮 ��ư��

    [Header("����ٴϰ� �Ǵ� ������Ʈ")]
    [SerializeField] private GameObject     followedObj;
                     private SpriteRenderer followedRenderer = null;
                     private bool           follow   = false; // ����ٴϴ���
                     private ItemVO         lastItem = null;  // ����ٴϰ� �ִ� ������Ʈ

    static private Inventory inst; // static �Լ� ���� �뵵


    private void Start()
    {
        inst = this;
        LinkFunctions();
        followedRenderer = followedObj.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.Log(follow);
        FollowCursor();
    }

    // Ȱ��ȭ�ɶ����� ������
    private void OnEnable()
    {
        SetSprite();
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
    /// ����ٴϰ� �ִ� �������� �����մϴ�.
    /// </summary>
    /// <returns>true when following</returns>
    static public bool IsFollowing()
    {
        return inst.follow;
    }

    #endregion
}