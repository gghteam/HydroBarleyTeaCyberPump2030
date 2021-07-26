using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GeneralMove : MonoBehaviour
{
    [SerializeField]
    private float moveDistance = 100;

    [SerializeField]
    private LayerMask ObtacleMask;

    public bool isMoving = false;


    /// <summary>
    /// 방향을 정해주면 이동 가능 체크 및 이동 함수
    /// </summary>
    /// <param name="dir"> 방향 </param>
    public void Moving(Vector3 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1,ObtacleMask);
        Debug.DrawRay(transform.position, dir);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            //GameManager.Instance.CameraShaking(0.5f);
            isMoving = false;
        }
        else
        {
            Vector3 nextPos = transform.position + new Vector3(dir.x * moveDistance, dir.y * moveDistance);
            transform.DOMove(nextPos, 0.1f).OnComplete(()=> { isMoving = false; });
        }

    }
}
