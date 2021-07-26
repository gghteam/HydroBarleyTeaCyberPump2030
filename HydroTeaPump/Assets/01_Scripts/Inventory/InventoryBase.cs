using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBase : MonoBehaviour
{

    static private InventoryBase                inst            = null;                                // static �Լ� ��
           private Dictionary<ItemEnum, ItemVO> inventory       = new Dictionary<ItemEnum, ItemVO>();  // �κ��丮 ��ųʸ�
           private GameObject                   inventoryPannel = null;                                // ���� �κ��丮

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
    /// ������ ������ �� �ִ��� Ȯ���ϴ� �Լ�
    /// </summary>
    /// <param name="itemEnum">������ ������</param>
    /// <param name="itemVO">������ �� ���� �� ������ �������� ������ ���</param>
    /// <returns>false when item count is 0 or less</returns>
    static public bool TryGetItem(ItemEnum itemEnum, out ItemVO itemVO)
    {
        if (inst.inventory[itemEnum].count < 1)
        {
            itemVO = null;
            return false;
        }


        itemVO = inst.inventory[itemEnum]; // TODO : ���� �� �������� ����
        
        return true;
    }

    /// <summary>
    /// �������� ���� ������ ������ �� ����
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
    /// �������� �߰���
    /// </summary>
    /// <param name="vo">�߰��� �������� vo</param>
    /// <returns>false when fail</returns>
    static public bool AddItem(ItemVO vo)
    {
        // �̹� �������� ������ �ִ� ��� ������ ����
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
    /// �κ��丮�� ���ų� �ݽ��ϴ�.
    /// </summary>
    static public void ToggleInventory()
    {
        inst.inventoryPannel.SetActive(!inst.inventoryPannel.activeSelf);
    }

    #endregion
}
