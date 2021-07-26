using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Button[] btnList;

    static public ItemVO item = null;

    private void Awake()
    {
        // 인벤토리 칸 전부 가지고 옴
        btnList = GetComponentsInChildren<Button>();
    }

    // TODO : 만들어야함

}
