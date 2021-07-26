using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    private AsyncOperation    load;
    private WaitForEndOfFrame wait = new WaitForEndOfFrame();

    [SerializeField] private Button btnLoad = null;

    private void Awake()
    {
        if (NULLChecker.CheckNULL(btnLoad))
        {
            Debug.LogError("LoadingManager: You forgot to add button to me");
            this.enabled = false;
            return;
        }


        load = SceneManager.LoadSceneAsync(WhatToLoad());
        load.allowSceneActivation = false;
        btnLoad.gameObject.SetActive(false);
    }

    /// <summary>
    /// 로드할 씬을 리턴합니다.
    /// </summary>
    /// <returns>로드할 씬의 이름(string)</returns>
    private string WhatToLoad()
    {

        switch(SceneLoadManager.GetLastScene())
        {
            case "MainMenu":
                return "SelectStage";
                break;


            default:
                return "MainMenu";
                break;
        }

    }


    private IEnumerator LoadingStatus()
    {
        while (load.progress <= 0.9f)
        {
            yield return wait;
        }

        btnLoad.onClick.AddListener(() => { load.allowSceneActivation = true; });
    }
}
