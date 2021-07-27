using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleMove : GeneralMove
{
    public Vector3 dir;

    public int objectHp = 2;
    public enum ObtacleType
    {
        Breakable,
        UnBreakable,
        MovingBreakable
    }

    public ObtacleType obtacleType = ObtacleType.UnBreakable;

    public void ObtacleMoving()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1, ObtacleMask);
        switch (obtacleType)
        {
            case ObtacleType.Breakable:
                Debug.Log("±úÁú ¼ö ÀÖÀ½");
                CheckBreakable();
                break;
            case ObtacleType.UnBreakable:
                if (hit.collider == null)
                {
                    Moving(dir);
                }
                    break;
            case ObtacleType.MovingBreakable:
                if (hit.collider != null)
                {
                    CheckBreakable();
                }
                else
                {
                    Moving(dir);
                }
                    break;
            default:
                break;
        }
    }
    public void CheckBreakable()
    {
        if(objectHp <=0)
        {
            Destroy(gameObject);
        }
        else
        {
            --objectHp;
        }
    }
}
