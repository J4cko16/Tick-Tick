using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    private Vector2 targetPos;

    [Header("Movement Settings")]
    public float movementDistance;
    public float minX;
    public float maxX;

    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) && transform.position.x > minX))
        {
            targetPos = new Vector2(transform.position.x - movementDistance, transform.position.y);
            transform.position = targetPos;
        }

        if ((Input.GetKeyDown(KeyCode.D) && transform.position.x < maxX))
        {
            targetPos = new Vector2(transform.position.x + movementDistance, transform.position.y);
            transform.position = targetPos;
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minX))
        {
            targetPos = new Vector2(transform.position.x - movementDistance, transform.position.y);
            transform.position = targetPos;
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxX))
        {
            targetPos = new Vector2(transform.position.x + movementDistance, transform.position.y);
            transform.position = targetPos;
        }

    }                      

}
