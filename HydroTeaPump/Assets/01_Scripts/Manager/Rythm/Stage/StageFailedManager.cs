using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
    }
    private void Update()
    {
        Zoom();
        if(zoom == vCamSmallerSize && !isLoadScene)
        {
            isLoadScene = true;
            SceneLoadManager.LoadSceneAdditive("CutSceneScene");
        }
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
