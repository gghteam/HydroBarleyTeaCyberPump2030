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

    private KeyCode nextKey;
    private KeyCode prevKey;
    private KeyCode selectKey;

    void Start()
    {
        firstPos = map.position;
        map.position += new Vector3(-1000, -1110, 0);
        lastPos = map.position;
        PopUp(1f);

        Select.SelectFrom(stages);
        Select.SetKey(OptionManager.GetSettings(KeyMapEnum.right), OptionManager.GetSettings(KeyMapEnum.left), OptionManager.GetSettings(KeyMapEnum.select));

        nextKey = OptionManager.GetSettings(KeyMapEnum.right);
        prevKey = OptionManager.GetSettings(KeyMapEnum.left);
        selectKey = OptionManager.GetSettings(KeyMapEnum.select);
    }

    // Update is called once per frame
    void Update()
    {
        Select.MoveSelect();
        Debug.Log(Select.GetIndex());
        if (Input.GetKey(nextKey) || Input.GetKey(prevKey) || Input.GetKey(selectKey) && canMove)
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
