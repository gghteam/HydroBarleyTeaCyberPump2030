using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StageFailedManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vCam = null;
    [SerializeField]
    private Transform cvsUI = null;

    public int vCamSmallerSize = 1;
    public int vCamSize = 5;
    private float zoom = 0;
    private bool isZoom = false;
    public float zoomSpeed = 2;

    private bool isLoadScene = false;

    public Transform stageFailedPanel = null;

    private Vector3 stageFailedPanelFisrtScale;
    public void FailedStage()
    {
        if (vCam != null) 
        {
            isZoom = true;
            cvsUI.GetComponent<CanvasGroup>().DOFade(0, 1);
        }
        else
        {
            Debug.Log("카메라챙겨요");
        }
    }

    private void Start()
    {
        zoom = vCamSize;
        stageFailedPanelFisrtScale = stageFailedPanel.localScale;
        stageFailedPanel.localScale = stageFailedPanel.localScale / 2;
        stageFailedPanel.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(zoom == vCamSmallerSize && !isLoadScene)
        {
            isLoadScene = true;
            stageFailedPanel.gameObject.SetActive(true);
            //stageFailedPanel.transform.position = new Vector3();
            stageFailedPanel.GetChild(0).GetComponent<Text>().text = "클리어 실패!";
            stageFailedPanel.gameObject.SetActive(true);
            stageFailedPanel.DOScale(stageFailedPanelFisrtScale, .5f).SetEase(Ease.OutBack).OnComplete(()=> {
                Invoke("NextSceneLoad", 3f);
            });
        }
        else if(zoom != vCamSmallerSize)
        {
            Zoom();
        }
    }
    public void NextSceneLoad()
    {
        SceneLoadManager.LoadSceneAdditive("CutSceneScene");
    }
    public void Zoom()
    {
        vCam.m_Lens.OrthographicSize = zoom;
        if (isZoom)
        {
            if (zoom <= vCamSmallerSize)
            {
                zoom = vCamSmallerSize;
            }
            else
            {
                zoom -= Time.deltaTime * zoomSpeed;
            }
        }
    }
}
