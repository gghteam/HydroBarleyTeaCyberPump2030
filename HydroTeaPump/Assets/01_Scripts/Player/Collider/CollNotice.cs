using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollNotice : MonoBehaviour
{
    private BoxCollider2D coll  = null;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollSelectable select = collision.GetComponent<ICollSelectable>();
        select?.ToggleNotice();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ICollSelectable select = collision.GetComponent<ICollSelectable>();
        select?.ToggleNotice();
    }
}
