using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 기능 관련 (또는 기반)
public class InventoryBase : MonoBehaviour
{

    static private InventoryBase                inst            = null;                                // static 함수 용
           private Dictionary<ItemEnum, ItemVO> inventory       = new Dictionary<ItemEnum, ItemVO>();  // 인벤토리 딕셔너리

    #region init, includes Awake

    private void Awake()
    {
        inst = this;

        SetItemData(true);
    }

    #endregion

    #region Item

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

        inventory.Add(ItemEnum.Star,     new ItemVO(ItemEnum.Star,     count, 0));
        inventory.Add(ItemEnum.Mermaid,  new ItemVO(ItemEnum.Mermaid,  count, 0));
        inventory.Add(ItemEnum.Flower,   new ItemVO(ItemEnum.Flower,   count, 0));
        inventory.Add(ItemEnum.WolfTear, new ItemVO(ItemEnum.WolfTear, count, 0));
        inventory.Add(ItemEnum.Fog,      new ItemVO(ItemEnum.Fog,      count, 0));
        inventory.Add(ItemEnum.Moon,     new ItemVO(ItemEnum.Moon,     count, 0));
    }



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
}
