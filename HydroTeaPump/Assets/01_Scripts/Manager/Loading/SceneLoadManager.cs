using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    static private SceneLoadManager inst; // static Á¢±Ù¿ë
           private Stack<string> sceneHistory;


    private void Awake()
    {
        inst = this;
        DontDestroyOnLoad(this);
    }

    static public void LoadScene(string sceneName)
    {
        inst.sceneHistory.Push(SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("Loading");
    }

    static public string GetLastScene()
    {
        return inst.sceneHistory.Count == 0 ? "null" : inst.sceneHistory.Pop();
    }
}
