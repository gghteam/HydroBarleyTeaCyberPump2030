using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStage : SelectObjectBase
{
    [SerializeField] private GameObject objNotice = null;

    private void Awake()
    {
        objNotice.SetActive(false);
    }

    public override void OnSelect()
    {
        base.OnSelect();

        SceneLoadManager.LoadScene("Stage");
    }

    public override void ToggleNotice()
    {
        base.ToggleNotice();

        objNotice.SetActive(!objNotice.activeSelf);
    }
}
