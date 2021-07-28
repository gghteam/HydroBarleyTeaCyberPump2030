using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStage : SelectObjectBase
{
    [SerializeField] private string nextScene = "";

    public override void OnSelect()
    {
        base.OnSelect();
        if (GameManager.Instance.isPopupOpen) return;

        SceneLoadManager.LoadSceneAdditive(nextScene);
        GameManager.Instance.isPopupOpen = true;
    }

    public override void OnClose()
    {
        if (!GameManager.Instance.isPopupOpen) return;

        if (nextScene == "MapScene")
        {
            MapUi mapManager = GameObject.Find("Piece").GetComponent<MapUi>();
            mapManager.PopDown(.5f);
        }
        else
        {
            SceneLoadManager.UnLoadScene(nextScene);
        }

        GameManager.Instance.isPopupOpen = false;
    }
}
