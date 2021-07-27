using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStage : SelectObjectBase
{
    [SerializeField] private string nextScene = "";

    bool isSceneOpen = false;
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
            else
            {
                SceneLoadManager.UnLoadScene(nextScene);
            }
        }
        else
        {
            SceneLoadManager.LoadSceneAdditive(nextScene);
        }
        GameManager.Instance.isPopupOpen = !GameManager.Instance.isPopupOpen;
    }
}
