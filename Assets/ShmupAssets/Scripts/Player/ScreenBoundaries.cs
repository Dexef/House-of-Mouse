﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void LateUpdate()
    {
        Vector3 objectPosition = transform.position;
        objectPosition.x = Mathf.Clamp(objectPosition.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        objectPosition.y = Mathf.Clamp(objectPosition.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);

        transform.position = objectPosition;
    }
}