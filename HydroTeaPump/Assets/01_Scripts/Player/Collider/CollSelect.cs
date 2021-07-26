using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Select
public partial class CollSelect : MonoBehaviour
{
                     private BoxCollider2D coll  = null;
    [SerializeField] private PlayerInput   input = null;

    // �浹 �� true
    private bool isCollision = false;

    // �浹�� ������Ʈ�� ICollSelectable
    ICollSelectable col = null;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        coll.enabled = true;
    }

    private void Update()
    {
        Select();
    }

    private void Select()
    {
        if (input.select)
        {
            input.DisableSelect();
            col?.OnSelect();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCollision = true;
        col = collision.GetComponent<ICollSelectable>();
        col?.ToggleNotice();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollision = false;
        col = collision.GetComponent<ICollSelectable>();
        col?.ToggleNotice();
    }
}