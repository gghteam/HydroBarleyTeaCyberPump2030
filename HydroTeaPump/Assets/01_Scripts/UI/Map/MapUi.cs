using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUi : MonoBehaviour
{
    [SerializeField]
    private Transform map = null;

    private Vector3 firstPos;
    private Vector3 lastPos;

    void Start()
    {
        firstPos = map.position;
        map.position += new Vector3(-10, -10, 0);
        lastPos = map.position;
        PopUp(.5f);
    }

    
    void Update()
    {
        
    }

    public void PopUp(float dur)
    {
        map.DOMove(firstPos, dur);
    }

    public void PopDown(float dur)
    {
        map.DOMove(lastPos, dur);
    }
}
