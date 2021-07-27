using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GeneralMove : MonoBehaviour
{
    [SerializeField]
    private float moveDistance = 100;

    [SerializeField]
    protected LayerMask ObtacleMask;

    public bool isMoving = false;


    /// <summary>
    /// ������ �����ָ� �̵� ���� üũ �� �̵� �Լ�
    /// </summary>
    /// <param name="dir"> ���� </param>
    public void Moving(Vector3 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1,ObtacleMask);
        //Debug.DrawRay(transform.position, dir);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            //GameManager.Instance.CameraShaking(0.5f);
            isMoving = false;
            if (hit.collider.gameObject.layer == 8)
            {
                if (gameObject.GetComponent<RythmPlayerMove>() != null)
                {
                    hit.collider.GetComponent<ObtacleMove>().dir = dir;
                    hit.collider.GetComponent<ObtacleMove>().ObtacleMoving();
                }
            }
        }
        else
        {
            Vector3 nextPos = transform.position + new Vector3(dir.x * moveDistance, dir.y * moveDistance);
            transform.DOMove(nextPos, 0.1f).OnComplete(() => { isMoving = false; });
        }

    }
}
