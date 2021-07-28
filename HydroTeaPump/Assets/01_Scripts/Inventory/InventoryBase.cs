using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 기능 관련 (또는 기반)
public class InventoryBase : MonoBehaviour
{

    static private InventoryBase                inst        = null;                               // static 함수 용
           private Dictionary<ItemEnum, ItemVO> inventory   = new Dictionary<ItemEnum, ItemVO>(); // 인벤토리 딕셔너리
           private ItemVO[]                     items       = new ItemVO[6];                      // 아이탬 배열
           public  InventoryVO                  inventoryVO = null;                               // 인벤토리 저장
    #region init, includes Awake

    private void Awake()
    {
        inst = this;

        SetItemData(true);
    }

    /// <summary>
    /// 아이탬 기본 데이터를 인벤토리에 저장
    /// </summary>
    private void SetItemData(bool debug = false)
    {
        int count = 0;

        if (debug)
        {
            count = 1;
        }

        bool[] itemStatus = new bool[5];
        itemStatus = GameManager.Instance.GetStageClearStat();

        // 아이탬 초기화
        items[0] = new ItemVO(ItemEnum.Star,     (itemStatus[0] ? 1 : 0), 0);
        items[1] = new ItemVO(ItemEnum.Mermaid,  1, 0);
        items[2] = new ItemVO(ItemEnum.Flower,   (itemStatus[1] ? 1 : 0), 0);
        items[3] = new ItemVO(ItemEnum.WolfTear, (itemStatus[2] ? 1 : 0), 0);
        items[4] = new ItemVO(ItemEnum.Fog,      (itemStatus[3] ? 1 : 0), 0);
        items[5] = new ItemVO(ItemEnum.Moon,     (itemStatus[4] ? 1 : 0), 0);

        // 딕셔너리에 추가
        for (int i = 0; i < items.Length; ++i)
        {
            inventory.Add((ItemEnum)i, items[i]);
        }

        // VO 에 넣어둠
        inventoryVO = new InventoryVO(items);
    }
    #endregion

    #region Get, check

    /// <summary>
    /// 아이탬 가져올 수 있는지 확인하는 함수
    /// </summary>
    /// <param name="itemEnum">가져올 아이탬</param>
    /// <param name="itemVO">가져올 수 있을 시 가져온 아이탬의 정보가 담김</param>
    /// <returns>false when item count is 0 or less</returns>
    static public bool TryGetItem(ItemEnum itemEnum, ref ItemVO itemVO)
    {
        if (!inst.inventory.ContainsKey(itemEnum))
        {
            Debug.LogError($"Request key: {itemEnum} does not exists");
            return false;
        }

        if (inst.inventory[itemEnum].count < 1)
        {
            itemVO = null;
            return false;
        }

        itemVO = inst.inventory[itemEnum];

        return true;
    }

    /// <summary>
    /// 아이탬의 대한 정보를 가져올 수 있음
    /// </summary>
    /// <param name="itemEnum"></param>
    /// <returns>inventory[itemEnum]</returns>
    static public ItemVO CheckItem(ItemEnum itemEnum)
    {
        if (!inst.inventory.ContainsKey(itemEnum))
        {
            Debug.LogError($"Inventory: Request ItemEnum does not exist.\r\nItemEnum: {itemEnum}");
            return null;
        }

        return new ItemVO(inst.inventory[itemEnum].itemEnum, inst.inventory[itemEnum].count, inst.inventory[itemEnum].weight);
    }
    #endregion

    #region AddItem

    /// <summary>
    /// 아이탬을 추가함
    /// </summary>
    /// <param name="vo">추가할 아이탬의 vo</param>
    /// <returns>false when fail</returns>
    static public bool AddItem(ItemVO vo)
    {
        if (inst.inventory.ContainsKey(vo.itemEnum))
        {
            inst.inventory[vo.itemEnum].count = 1;
            return true;
        }

        Debug.LogError($"AddItem: Cannot find key: {vo.itemEnum}");
        return false;
    }

    /// <summary>
    /// 아이탬을 하나 추가함
    /// </summary>
    /// <param name="itemEnum">추가할 아이탬의 enums</param>
    /// <returns>false when fail</returns>
    static public bool AddItem(ItemEnum itemEnum)
    {
        if (inst.inventory.ContainsKey(itemEnum))
        {
            inst.inventory[itemEnum].count = 1;
            return true;
        }

        Debug.LogError($"AddItem: Cannot find key: {itemEnum}");
        return false;
    }

    #endregion


    #region InventoryVO

    static public InventoryVO GetInventory()
    {
        return inst.inventoryVO;
    }
    #endregion
}
