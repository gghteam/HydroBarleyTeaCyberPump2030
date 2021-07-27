using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI.Management.Button;
using UI.Interactive.Button;

public class CraftUI : MonoBehaviour
{
    [SerializeField] private List<Button> btnCraftList = new List<Button>(); // �۾� ���̺�
    [SerializeField] private Button       btnCraft     = null; // ���չ�ư
                     private CraftAnim anim = null; // ���� ���ϸ��̼�


    // ���̺� �� �����Ƶ�
    private ItemVO[] craftTable = new ItemVO[3];

    private bool isClear = false;

    // ��� ���� ����
    bool isStar;
    bool isWolf;
    bool isFog;

    private void Awake()
    {
        isClear = false;
        anim = GetComponent<CraftAnim>();
    }

    private void Start()
    {
        InitArray();
        InitButton();

        // ��ư ���� ������ �߰�
        for (int i = 0; i < btnCraftList.Count; ++i)
        {
            Select.AddFrom(btnCraftList[i]);
        }
        Select.AddFrom(btnCraft);
    }

    /// <summary>
    /// �۾����̺��� �����մϴ�.
    /// </summary>
    /// <returns>List of button</returns>
    public List<Button> GetTable()
    {
        return btnCraftList;
    }

    public bool Success()
    {
        return isClear;
    }

    /// <summary>
    /// ������ Ʋ�ȴ��� �� �� �ִ� �Լ�
    /// </summary>
    /// <returns>bool[3] { isStar, isWolf, isFog }</returns>
    public bool[] GetWhatIsWrong()
    {
        return new bool[] {isStar, isWolf, isFog };
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
        isStar = false;
        isWolf = false;
        isFog  = false;

        
        // ���� ���̺� Ȯ��
        for (int i = 0; i < craftTable.Length; ++i)
        {
            // �ƹ��͵� ������ �����Ű�� ����
            if (craftTable[i] == null)
            {
                return;
            }

            isStar = !isStar ? craftTable[i].itemEnum == ItemEnum.Star     : true;
            isWolf = !isWolf ? craftTable[i].itemEnum == ItemEnum.WolfTear : true;
            isFog  = !isFog  ? craftTable[i].itemEnum == ItemEnum.Fog      : true;
        }

        anim.Animation();

        // ���� Ȯ��
        if (isStar && isWolf && isFog)
        {
            Debug.Log("all correct");
            isClear = true;
        }
        else // ���� Ʋ���� �˷���
        {
            isClear = false;
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
    /// �迭 �ʱ�ȭ
    /// </summary>
    private void InitArray()
    {
        for (int i = 0; i < craftTable.Length; ++i)
        {
            craftTable[i] = null;
        }
    }

    /// <summary>
    /// ��ư �ʱ�ȭ
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
