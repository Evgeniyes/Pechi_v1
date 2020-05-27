using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMove : MonoBehaviour
{
    public float startHeightY = 3.0f;
    public Vector3 toPos;
    public bool moveBrick = false;
    public bool moveBrickToUp = false;
    public float speedFall = 0.1f;

    void Start()
    {
        toPos = transform.position;         //Устанавливаем точку где должны находиться
        Vector3 pos = transform.position;   // Поднимаемся за экран
        pos.y += startHeightY;
        transform.position = pos;
        //gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (GameController.gameControl.pauseGame)
            return;

        if (moveBrick)
        {
            //print("moveBrick= " + moveBrick + " | toPos= " + toPos);
            //this.gameObject.SetActive(true);
            transform.position = Vector3.Lerp(transform.position, toPos, speedFall);
        } 
        
        if(moveBrickToUp)
        {
            //Перемещаем кирпич вверх
            Vector3 toUp = transform.position;
            toUp.y = startHeightY+toPos.y;
            transform.position = Vector3.Lerp(transform.position, toUp, speedFall);
        }
    }

}
