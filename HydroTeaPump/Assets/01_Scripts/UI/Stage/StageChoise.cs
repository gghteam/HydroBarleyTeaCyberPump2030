using System.Collections;
using System.Collections.Generic;
using UI.Interactive.Button;
using UnityEngine;

public class StageChoise : MonoBehaviour
{
    public void StageBtn()
    {
        GameManager.Instance.currentStage = Select.GetIndex();
        SceneLoadManager.LoadScene("Stage");
    }
}
