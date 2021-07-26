using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;

    UnityEngine.UI.Image noteImage;

    public bool isRightNote = true;
    void OnEnable()
    {
        if (noteImage == null)
            noteImage = GetComponent<UnityEngine.UI.Image>();
        noteImage.enabled = true;
    }

    void Update()
    {
        Vector3 dir = isRightNote ? Vector3.right :Vector3.left;
        transform.localPosition += dir * noteSpeed * Time.deltaTime;
    }
    public void HideNote()
    {
        noteImage.enabled = false;
    }
}
