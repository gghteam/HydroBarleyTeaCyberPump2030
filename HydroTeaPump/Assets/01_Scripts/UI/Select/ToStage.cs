using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStage : SelectObjectBase
{
    public override void OnSelect()
    {
        base.OnSelect();

        SceneManager.LoadScene("SelectStage"); // 또는 로딩
    }
}
