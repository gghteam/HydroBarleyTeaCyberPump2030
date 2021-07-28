using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPannel : MonoBehaviour
{
    [SerializeField] private GameObject endPannel;
    
    [SerializeField] private Button btnMain;
    [SerializeField] private Button retry;

    bool called = false;

    private void Start()
    {
        endPannel.SetActive(false);

        CutScene.SetCallback(() => { endPannel.SetActive(true); });

        btnMain.onClick.AddListener(() => SceneLoadManager.LoadScene("MainMenu"));
        retry.onClick.AddListener(() => { SceneLoadManager.LoadScene("Stage"); });
    }

}
