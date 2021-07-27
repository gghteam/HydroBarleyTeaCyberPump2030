using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleMove : GeneralMove
{
    public Vector3 dir;

    public void ObtacleMoving()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1, ObtacleMask);
        if (hit.collider == null)
        {
            Moving(dir);
        }
    }
}
