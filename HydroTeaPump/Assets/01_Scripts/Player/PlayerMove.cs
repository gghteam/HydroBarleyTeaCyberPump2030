using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerMove : MonoBehaviour
{
    private PlayerInput input = null;

    private Vector3 move = Vector3.right;

    [Header("이동 속도")]
    [SerializeField] private float speed = 1.0f;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isPopupOpen)
            Move();
    }

    /// <summary>
    /// 움직이는 함수
    /// </summary>
    private void Move()
    {
        if (input.right)
        {
            transform.position += move * speed * Time.deltaTime;
        }

        if (input.left)
        {
            transform.position += -move * speed * Time.deltaTime;
        }
    }

}