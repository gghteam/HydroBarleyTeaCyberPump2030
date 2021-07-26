using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Interactive.Button;
using UnityEngine.UI;

public class MapUi : MonoBehaviour
{
    [SerializeField]
    private Transform map = null;

    private Vector3 firstPos;
    private Vector3 lastPos;

    public Button[] stages;

    private bool canMove = false;
    void Start()
    {
        firstPos = map.position;
        map.position += new Vector3(-1000, -1110, 0);
        lastPos = map.position;
        PopUp(1f);

        Select.SelectFrom(stages);
        Select.SetKey(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Space);
    }

    // Update is called once per frame
    void Update()
    {
        Select.MoveSelect();
        Debug.Log(Select.GetIndex());
        if (Input.anyKeyDown && canMove)
        {
            canMove = false;
            Select.MoveNext();
            Select.MovePrev();
            transform.DOMove(stages[Select.GetIndex()].transform.position, .5f).OnComplete(() => { canMove = true; });
        }
    }
    public void PopUp(float dur)
    {
        map.DOMove(firstPos, dur).OnComplete(()=> { canMove = true; });
    }

    public void PopDown(float dur)
    {
        map.DOMove(lastPos, dur).OnComplete(()=> { SceneLoadManager.UnLoadScene("MapScene"); });
    }
}
