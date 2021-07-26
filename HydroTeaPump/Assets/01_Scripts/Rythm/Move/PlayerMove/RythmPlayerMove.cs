using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RythmPlayerMove : GeneralMove
{
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

        Vector3 dir = new Vector3(h, v, 0);
        Moving(dir);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 11)
        {
            Debug.Log("¤È! È¹µæ!");
        }
    }
    
}
