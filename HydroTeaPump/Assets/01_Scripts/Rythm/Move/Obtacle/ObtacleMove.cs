using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleMove : GeneralMove
{
    public Vector3 dir;

    public int objectHp = 1;

    public Sprite[] obtacleSprites = null;
    public Sprite brokenObtacleSprite = null;
    public enum ObtacleType
    {
        Breakable = 0,
        UnBreakable = 1,
        MovingBreakable = 2
    }

    public ObtacleType obtacleType = ObtacleType.UnBreakable;

    private void Start()
    {
        Setting();
    }

    public void Setting()
    {
        if(obtacleSprites.Length >= (int)obtacleType)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = obtacleSprites[(int)obtacleType];
        }
    }

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
            if(obtacleType == ObtacleType.Breakable)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = brokenObtacleSprite;
                Invoke("DestroyObj", 0.2f);
            }    
            else
            {
                DestroyObj();
            }
        }
        else
        {
            --objectHp;
        }
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}
