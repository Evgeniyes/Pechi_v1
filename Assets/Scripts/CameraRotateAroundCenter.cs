using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraRotateAroundCenter : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float sensitivity = 3; // чувствительность мышки
    public float limit = 90; // ограничение вращения по Y вверх
    public float limitNizBase = 15; // ограничение вращения по Y внизу
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 3; // макс. увеличение
    public float zoomMin = 1; // мин. увеличение
    private float X, Y = 1.0f;

    bool moveCam = false; //Перемещать ли камеру

    void Start()
    {
        moveCam = true;
        MoveCam(30);
        moveCam = false;
        /*limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset = new Vector3(transform.position.x, transform.position.y, -Mathf.Abs(zoomMax) / 10);
        transform.position = target.position + offset;*/

    }


    void Update()
    {
        if (GameController.gameControl.pauseGame)
            return;

        MoveCam(limitNizBase);

    }

    void MoveCam(float limitNiz)
    {
        /*
        if (Input.GetMouseButtonDown(0))
            moveCam = true;
        else if (Input.GetMouseButtonUp(0))
            moveCam = false;

        if (moveCam)
        {
            target.transform.Rotate(0, Input.GetAxis("Mouse Y")*(sensitivity * Time.deltaTime), 0);
        }
        */

        //Делаем зум
        if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

        //Перемещаем камеру
        if (Input.GetMouseButtonDown(0))
        {
            moveCam = true;
        }
        else if (Input.GetMouseButtonUp(0))
            moveCam = false;

        if (moveCam)
        {
            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            Y += Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, -limit, -limitNiz);
            transform.localEulerAngles = new Vector3(-Y, X, 0);
           // print(limitNiz);
           
        }

        transform.position = transform.localRotation * offset + target.position;
    }

}
