using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    static private SceneLoadManager inst; // static Á¢±Ù¿ë
           private Stack<string>    sceneRequest;


    private void Awake()
    {
        inst = this;
        DontDestroyOnLoad(this);
    }

    static public void LoadScene(string sceneName)
    {
        inst.sceneRequest.Push(sceneName);

        SceneManager.LoadScene("Loading");
    }

    static public string GetLastRequest()
    {
        return inst.sceneRequest.Count == 0 ? "null" : inst.sceneRequest.Pop();
    }
}
