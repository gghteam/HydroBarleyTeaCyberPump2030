using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStage : SelectObjectBase
{
    [SerializeField] private GameObject objNotice = null;

    [SerializeField] private string nextScene = "";

    bool isSceneOpen = false;

    private void Awake()
    {
        objNotice.SetActive(false);
    }

    public override void OnSelect()
    {
        base.OnSelect();
        Debug.Log("SSSSS");
        if(GameManager.Instance.isPopupOpen)
        {
            if(nextScene == "MapScene")
            {
                MapUi mapManager = GameObject.Find("Piece").GetComponent<MapUi>();
                mapManager.PopDown(.5f);
            }
        }
        else
        {
            if (isSceneOpen)
            {
                isSceneOpen = false;
                SceneLoadManager.UnLoadScene(nextScene);
            }
            else
            {
                isSceneOpen = true;
                SceneLoadManager.LoadSceneAdditive(nextScene);
            }
        }
        GameManager.Instance.isPopupOpen = !GameManager.Instance.isPopupOpen;
    }

    public override void ToggleNotice()
    {
        base.ToggleNotice();

        objNotice.SetActive(!objNotice.activeSelf);
    }
}
