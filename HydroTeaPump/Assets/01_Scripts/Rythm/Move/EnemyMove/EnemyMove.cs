using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMove : GeneralMove
{

    /// <summary>
    /// 에너미라고 해놨지만 알고보면 그냥 이동하는 장애물
    /// </summary>
    public void EnemyMoving()
    {
        int h = Random.Range(-1 ,2);
        int v = Random.Range(-1, 2);
        if( h !=0)
        {
            v = 0;
            if (h > 1) 
            {
                h = 1;
            }
        }
        if(v > 1)
        {
            v = 1;
        }
        Vector3 dir = new Vector3(h, v, 0);
        Moving(dir);
    }
}
