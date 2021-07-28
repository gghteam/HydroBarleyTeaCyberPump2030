using System.Collections;
using System.Collections.Generic;
using UI.Interactive.Button;
using UnityEngine;

public class StageChoise : MonoBehaviour
{
    public void StageBtn()
    {
        if (GameManager.Instance.GetStageClearStat()[0] == false)
        {
            int idx = Select.GetIndex();
            if(idx != 0)
            {
                return;
            }
            SceneLoadManager.LoadScene("Stage");
        }
        else
        {
            GameManager.Instance.currentStage = Select.GetIndex();
            SceneLoadManager.LoadScene("Stage");
        }

    }
}
