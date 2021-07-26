using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StagePlayerMove : GeneralMove
{
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
}
