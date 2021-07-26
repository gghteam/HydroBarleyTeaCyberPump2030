using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI.Management.Button;
using UI.Interactive.Button;

public class CraftUI : MonoBehaviour
{
    [SerializeField] private List<Button> btnCraftList = new List<Button>(); // 작업 테이블
    [SerializeField] private Button       btnCraft     = null; // 조합버튼

    // 테이블에 들어간 아이탬들
    private ItemVO[] craftTable = new ItemVO[3];


    private void Awake()
    {
        
    }

    private void Start()
    {
        InitArray();
        InitButton();

        // 버튼 선택 범위에 추가
        for (int i = 0; i < btnCraftList.Count; ++i)
        {
            Select.AddFrom(btnCraftList[i]);
        }
        Select.AddFrom(btnCraft);
    }

    private void AddToTable(int idx)
    {
        if (!Inventory.IsFollowing())
        {
            return;
        }

        if (craftTable[idx] != null)
        {
            InventoryBase.AddItem(craftTable[idx]);
        }

        craftTable[idx] = Inventory.GetCurrentItem();
        btnCraftList[idx].image.sprite = Inventory.GetItemSprite(craftTable[idx].itemEnum);
    }

    private void Craft()
    {
        bool isStar = false;
        bool isWolf = false;
        bool isFog  = false;

        // 조합 테이블 확인
        for (int i = 0; i < craftTable.Length; ++i)
        {
            isStar = !isStar ? craftTable[i].itemEnum == ItemEnum.Star     : true;
            isWolf = !isWolf ? craftTable[i].itemEnum == ItemEnum.WolfTear : true;
            isFog  = !isFog  ? craftTable[i].itemEnum == ItemEnum.Fog      : true;
        }


        // 조합 확인
        if (isStar && isWolf && isFog)
        {
            Debug.Log("all correct");
        }
        else // 뭐가 틀린지 알려줌
        {
            if (isStar)
            {
                Debug.Log("isStar is correct");
            }
            if (isWolf)
            {
                Debug.Log("isWolf is correct");
            }
            if (isFog)
            {
                Debug.Log("isFog is correct");
            }
        }
    }

    #region init

    /// <summary>
    /// 배열 초기화
    /// </summary>
    private void InitArray()
    {
        for (int i = 0; i < craftTable.Length; ++i)
        {
            craftTable[i] = null;
        }
    }

    /// <summary>
    /// 버튼 초기화
    /// </summary>
    private void InitButton()
    {
        for (int i = 0; i < btnCraftList.Count; ++i)
        {
            int idx = i;
            ButtonManagement.AddEvent(btnCraftList[i], () => AddToTable(idx));
        }

        btnCraft.onClick.AddListener(Craft);
    }

    #endregion

    
}
