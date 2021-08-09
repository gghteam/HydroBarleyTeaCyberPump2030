using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    static private SceneLoadManager inst; // static Á¢±Ù¿ë
           private Stack<string>    sceneRequest = new Stack<string>();

    static bool onMem = false;

    private void Awake()
    {
        if (onMem) return;

        inst = this;
        DontDestroyOnLoad(this);

        onMem = true;
    }

    static public void LoadScene(string sceneName)
    {
        inst.sceneRequest.Push(sceneName);

        SceneManager.LoadScene("Loading");
    }

    static public string GetLastRequest()
    {
        return inst.sceneRequest.Count == 0 ? null : inst.sceneRequest.Pop();
    }

    static public void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
    
    static public void UnLoadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
