using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� ���� (�Ǵ� ���)
public class InventoryBase : MonoBehaviour
{

    static private InventoryBase                inst        = null;                               // static �Լ� ��
           private Dictionary<ItemEnum, ItemVO> inventory   = new Dictionary<ItemEnum, ItemVO>(); // �κ��丮 ��ųʸ�
           private ItemVO[]                     items       = new ItemVO[6];                      // ������ �迭
           public  InventoryVO                  inventoryVO = null;                               // �κ��丮 ����
    #region init, includes Awake

    private void Awake()
    {
        inst = this;

        SetItemData(true);
    }

    /// <summary>
    /// ������ �⺻ �����͸� �κ��丮�� ����
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

        // ������ �ʱ�ȭ
        items[0] = new ItemVO(ItemEnum.Star,     (itemStatus[0] ? 1 : 0), 0);
        items[1] = new ItemVO(ItemEnum.Mermaid,  1, 0);
        items[2] = new ItemVO(ItemEnum.Flower,   (itemStatus[1] ? 1 : 0), 0);
        items[3] = new ItemVO(ItemEnum.WolfTear, (itemStatus[2] ? 1 : 0), 0);
        items[4] = new ItemVO(ItemEnum.Fog,      (itemStatus[3] ? 1 : 0), 0);
        items[5] = new ItemVO(ItemEnum.Moon,     (itemStatus[4] ? 1 : 0), 0);

        // ��ųʸ��� �߰�
        for (int i = 0; i < items.Length; ++i)
        {
            inventory.Add((ItemEnum)i, items[i]);
        }

        // VO �� �־��
        inventoryVO = new InventoryVO(items);
    }
    #endregion

    #region Get, check

    /// <summary>
    /// ������ ������ �� �ִ��� Ȯ���ϴ� �Լ�
    /// </summary>
    /// <param name="itemEnum">������ ������</param>
    /// <param name="itemVO">������ �� ���� �� ������ �������� ������ ���</param>
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
    #endregion

    #region AddItem

    /// <summary>
    /// �������� �߰���
    /// </summary>
    /// <param name="vo">�߰��� �������� vo</param>
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
    /// �������� �ϳ� �߰���
    /// </summary>
    /// <param name="itemEnum">�߰��� �������� enums</param>
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
        return inst?.inventoryVO;
    }
    #endregion
}
