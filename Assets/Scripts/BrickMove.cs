using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMove : MonoBehaviour
{
    public float startHeightY = 3.0f;
    public Vector3 toPos;
    public bool moveBrick = false;
    public float speedFall = 0.1f;

    void Start()
    {
        toPos = transform.position;         //Устанавливаем точку где должны находиться
        Vector3 pos = transform.position;   // Поднимаемся за экран
        pos.y += startHeightY;
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        if (moveBrick)
            transform.position = Vector3.Lerp(transform.position, toPos, speedFall);
    }

}
