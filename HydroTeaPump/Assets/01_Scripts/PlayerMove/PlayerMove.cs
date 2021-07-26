using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveDistance = 100;


    public void Moving()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 nextPos = transform.position + new Vector3(h * moveDistance, v * moveDistance);

        transform.DOMove(nextPos,0.1f);
    }
}
