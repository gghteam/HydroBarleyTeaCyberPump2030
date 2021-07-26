using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBase : MonoBehaviour
{

    static private InventoryBase                inst            = null;                                // static 함수 용
           private Dictionary<ItemEnum, ItemVO> inventory       = new Dictionary<ItemEnum, ItemVO>();  // 인벤토리 딕셔너리
           private GameObject                   inventoryPannel = null;                                // 실제 인벤토리

    #region init, includes Awake

    private void Awake()
    {
        inst = this;
        inventoryPannel = transform.GetChild(0).gameObject;
        inventoryPannel.SetActive(false);
    }

    #endregion

    #region Item

    /// <summary>
    /// 아이탬 가져올 수 있는지 확인하는 함수
    /// </summary>
    /// <param name="itemEnum">가져올 아이탬</param>
    /// <param name="itemVO">가져올 수 있을 시 가져온 아이탬의 정보가 담김</param>
    /// <returns>false when item count is 0 or less</returns>
    static public bool TryGetItem(ItemEnum itemEnum, out ItemVO itemVO)
    {
        if (inst.inventory[itemEnum].count < 1)
        {
            itemVO = null;
            return false;
        }


        itemVO = inst.inventory[itemEnum]; // TODO : 아직 다 구현되지 않음
        
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
        // 이미 아이탬을 가지고 있는 경우 수량만 더함
        if (inst.inventory.ContainsKey(vo.itemEnum))
        {
            inst.inventory[vo.itemEnum].count += vo.count;
            return true;
        }

        inst.inventory.Add(vo.itemEnum, vo);

        return true;
    }

    #endregion

    #region Display

    /// <summary>
    /// 인벤토리를 열거나 닫습니다.
    /// </summary>
    static public void ToggleInventory()
    {
        inst.inventoryPannel.SetActive(!inst.inventoryPannel.activeSelf);
    }

    #endregion
}
