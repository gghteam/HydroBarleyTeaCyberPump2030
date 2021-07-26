using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RythmPlayerMove : GeneralMove
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// ÇÃ·¹ÀÌ¾î ÀÌµ¿ÇÔ¼ö
    /// </summary>
    public void PlayerMoving()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0)
        {
            v = 0;
        }
        isMoving = true;

        Vector3 dir = new Vector3(h, v, 0);
        transform.localScale = new Vector3(h!=0? -h/2:transform.localScale.x, 0.5f, 1);
        Moving(dir);
    }

    private void Update()
    {
        animator.SetBool("Run", isMoving);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 11)
        {
            Debug.Log("¤È! È¹µæ!");
        }
    }
    
}
