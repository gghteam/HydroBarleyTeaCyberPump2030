using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerControl : MonoBehaviour
{
    private PlayerInput input = null;

    private Vector3 move = Vector3.right;

    [Header("이동 속도")]
    [SerializeField] private float speed = 1.0f;

    [Header("선택 컬라이더")]
    [SerializeField] private BoxCollider2D collSelect = null;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        collSelect.enabled = false;
    }

    private void Update()
    {
        Move();
        Select();
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


// Select
public partial class PlayerControl : MonoBehaviour
{
    private void Select()
    {
        if (input.select)
        {
            input.DisableSelect();
            collSelect.enabled = true;
            Debug.Log("selected");
            Invoke(nameof(DisableCollider), 0.2f);

        }
    }

    private void DisableCollider()
    {
        collSelect.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollSelectable select = collision.GetComponent<ICollSelectable>();
        select?.OnSelect();
    }
}