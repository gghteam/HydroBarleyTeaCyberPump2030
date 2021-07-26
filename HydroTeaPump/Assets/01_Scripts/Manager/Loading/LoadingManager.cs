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


        load = SceneManager.LoadSceneAsync(SceneLoadManager.GetLastRequest());
        load.allowSceneActivation = false;
        btnLoad.gameObject.SetActive(false);
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
