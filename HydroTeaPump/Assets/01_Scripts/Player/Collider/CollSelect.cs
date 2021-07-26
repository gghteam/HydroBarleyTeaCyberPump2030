using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Select
public partial class CollSelect : MonoBehaviour
{
                     private BoxCollider2D coll  = null;
    [SerializeField] private PlayerInput   input = null;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        coll.enabled = false;
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
            coll.enabled = true;
            Debug.Log("selected");
            Invoke(nameof(DisableCollider), 0.2f);
        }
    }

    private void DisableCollider()
    {
        coll.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!coll.enabled) return;
        ICollSelectable select = collision.GetComponent<ICollSelectable>();
        select?.OnSelect();
    }
}