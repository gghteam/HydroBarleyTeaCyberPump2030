using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftUI : MonoBehaviour
{
    [SerializeField] private List<Button> btnCraftList = new List<Button>();



    private void Awake()
    {
        foreach (Button btn in btnCraftList)
        {
            btn.onClick.AddListener(InventoryBase.ToggleInventory);
        }
    }

    private void AddToTable()
    {
        
    }
}
