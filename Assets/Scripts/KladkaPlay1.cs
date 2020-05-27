using System;
using System.Collections.Generic;
using UnityEngine;

public class KladkaPlay1 : MonoBehaviour
{
    public GameObject PointForLookCam;
    public GameObject brik1;
    public int counterBrick = 0;
    public GameObject[] brikArray;
    
    public List<GameObject> currentLayerBr = new List<GameObject>();
    float curY = 0.0f; //Высота текущего последнего-y для переноса

    void Start()
    {
        brikArray = GameObject.FindGameObjectsWithTag("Brik");
        //BuildLayerBrik();
    }

    void Update()
    {
        /*

        if (Input.GetMouseButtonDown(0))
        {
            //Вызываем функцию падения нижнего ряда
            BuildLayerBrik();
        }
        if (Input.GetMouseButtonDown(1))
        {
            //Вызываем функцию падения нижнего ряда
            LayerBrikUp();
        }*/
    }

    public void LayerBrikUp()
    {
        if (GameController.gameControl.pauseGame)
            return;

        float maxY = 0; //для поискам макс Y для перемещения

        // Находим все элементы которые были перемещены т.е. их Y меньше стартового значения
        List<GameObject> layerUp = new List<GameObject>();
        foreach (GameObject n in brikArray)
        {
            if (n.transform.position.y < n.GetComponent<BrickMove>().startHeightY)
                layerUp.Add(n);
            
        }

        foreach (GameObject bT in layerUp)  // Находим слой для перемещения
        {
            if (bT.transform.position.y > maxY)
                maxY = bT.transform.position.y;
        }

        curY = maxY;
        Vector3 newPosCam = PointForLookCam.transform.position;
        newPosCam.y = Mathf.Max(0, newPosCam.y - 0.06f);
        PointForLookCam.transform.position = newPosCam;

        foreach (GameObject curYmin in brikArray)
        {
            if (curYmin.transform.position.y == maxY)
            {
                curYmin.GetComponent<BrickMove>().moveBrickToUp = true;
                curYmin.GetComponent<BrickMove>().moveBrick = false;
            }
        }


    }


    //Определяем слой для переноса вниз
    public void BuildLayerBrik()
    {
        if (GameController.gameControl.pauseGame)
            return;

        float minY = 10.0f; //для поискам мин Y для перемещения
        Vector3 newPosPointCam = Vector3.zero;
        int counterItem = 0;

        List<GameObject> layer = new List<GameObject>();
        foreach(GameObject n in brikArray) // Находим все элементы которые еще не были перемещены и их Y больше последнего перемещенного слоя
        {
            if (n.transform.position.y > curY)
                layer.Add(n);
        }

        foreach (GameObject bT in layer)  // Находим слой для перемещения
        {
            if (bT.transform.position.y < minY)
                minY = bT.transform.position.y;
            //print("minY: " + minY + "curY = "+ curY + "bT.transform.position.y = "+ bT.transform.position.y);
        }

        foreach (GameObject curYmin in brikArray)
        {
            if (curYmin.transform.position.y == minY)
            {
                //print(curYmin.name);
                curYmin.GetComponent<BrickMove>().moveBrick = true;
                curYmin.GetComponent<BrickMove>().moveBrickToUp = false;

                //находим среднюю точку в слое
                newPosPointCam += curYmin.transform.position;
                counterItem++;
            }
        }
        curY = minY;
        if (counterItem == 0) return;
        newPosPointCam = new Vector3(0, (newPosPointCam.y/ counterItem)-3, 0);
        PointForLookCam.transform.position = newPosPointCam;
    }

}
