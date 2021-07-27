using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed;
    private Vector3 move;
    private Vector2 originPos;

    private void OnEnable()
    {
        speed = Random.Range(0.5f, 1.0f);
        move = new Vector3(-speed, 0);
        originPos = transform.position;
    }

    void Update()
    {
        transform.position += move * Time.deltaTime;

        if (transform.position.x < -18.0f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        transform.position = originPos;
    }
}
