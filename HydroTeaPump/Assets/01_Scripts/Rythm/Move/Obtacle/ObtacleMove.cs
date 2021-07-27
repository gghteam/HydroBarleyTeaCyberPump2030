using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleMove : GeneralMove
{
    public Vector3 dir;

    public void ObtacleMoving()
    {
        Moving(dir);
    }
}
