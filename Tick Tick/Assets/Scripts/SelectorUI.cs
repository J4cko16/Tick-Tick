using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorUI : MonoBehaviour
{
    private Vector2 targetPos;

    [Header("Movement Settings")]
    public float movementDistance;
    public float minY;
    public float maxY;

    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) && transform.position.y < maxY))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + movementDistance);
            transform.position = targetPos;
        }

        if ((Input.GetKeyDown(KeyCode.S) && transform.position.y > minY))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - movementDistance);
            transform.position = targetPos;
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + movementDistance);
            transform.position = targetPos;
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - movementDistance);
            transform.position = targetPos;
        }

    }

}
