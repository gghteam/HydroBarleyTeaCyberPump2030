using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerMove : MonoBehaviour
{
    private PlayerInput input = null;

    private Vector3 move = Vector3.right;

    private Animator animator;

    [Header("�̵� �ӵ�")]
    [SerializeField] private float speed = 1.0f;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.Instance.isPopupOpen = false;
    }

    private void Update()
    {
        if (!GameManager.Instance.isPopupOpen)
            Move();
    }

    /// <summary>
    /// �����̴� �Լ�
    /// </summary>
    private void Move()
    {
        if(!Input.anyKey)
        {
            //���̵� �ִϸ��̼�
            animator.SetBool("Walk", false);
        }
        else if (input.right || input.left)
        {
            //�̵� �ִϸ��̼�
            animator.SetBool("Walk", true);

            if (input.right)
            {
                transform.position += move * speed * Time.deltaTime;
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (input.left)
            {
                transform.position += -move * speed * Time.deltaTime;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
       
    }

}