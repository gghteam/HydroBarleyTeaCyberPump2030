using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerMove : MonoBehaviour
{
    private PlayerInput input = null;

    private Vector3 move = Vector3.right;

    private Animator animator;

    [Header("이동 속도")]
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
    /// 움직이는 함수
    /// </summary>
    private void Move()
    {
        if(!Input.anyKey)
        {
            //아이들 애니메이션
            animator.SetBool("Walk", false);
        }
        else if (input.right || input.left)
        {
            //이동 애니메이션
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