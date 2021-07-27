using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    private AsyncOperation    load;
    private WaitForEndOfFrame wait = new WaitForEndOfFrame();

    [SerializeField] private Transform beginPos; // �ε� ���� �κ�
    [SerializeField] private Transform endPos; // �ε� �� �κ�

    [SerializeField] private Button btnLoad = null;
    [SerializeField] private Transform loadingImage = null;



    private void Awake()
    {
        if (NULLChecker.CheckNULL(btnLoad))
        {
            Debug.LogError("LoadingManager: You forgot to add button to me");
            this.enabled = false;
            return;
        }

        string scene = SceneLoadManager.GetLastRequest();

        loadingImage.GetComponent<Animation>().Play(); // �ɾ�� ���ϸ��̼�

        load = SceneManager.LoadSceneAsync(scene == null ? "MainMenu" : scene);
        load.allowSceneActivation = false;
        btnLoad.gameObject.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(LoadingStatus());
    }



    private IEnumerator LoadingStatus()
    {
        while (load.progress <= 0.9f)
        {
            loadingImage.position = Vector3.Lerp(beginPos.position, endPos.position, load.progress);
            yield return wait;
        }

        loadingImage.position = endPos.position;
        btnLoad.onClick.AddListener(() => { load.allowSceneActivation = true; });
    }
}
