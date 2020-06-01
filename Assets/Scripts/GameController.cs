using MarkLight.Views.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameControl;
    public GameObject pauseBtn;
    public GameObject pausePanel;
    public GameObject addBtn;
    public GameObject upBtn;

    public bool pauseGame = false;

    private GameObject[] brikArray;
    private int currentRow = 0;
    public Text descRowText;

    public GameObject targetCameraPoint;
    public float stepHeightPoint = 0.09f;


    void Start()
    {
        gameControl = this;
        pausePanel.SetActive(false);

        brikArray = GameObject.FindGameObjectsWithTag("Row");

        foreach (GameObject g in brikArray)
        {
            g.SetActive(false);
        }

        AddRow(currentRow);


    }

    private void AddRow(int indexRow)
    {
        if (indexRow < brikArray.Length)
        {
            brikArray[indexRow].SetActive(true);
            brikArray[indexRow].transform.position = new Vector3(0, 5, 0);

            descRowText.text = "Ряд: " + (indexRow+1) +". "+ brikArray[indexRow].GetComponent<AddRow>().description;
            currentRow = Mathf.Min(++currentRow, brikArray.Length);
            //перемещаем точку для камеры выше
            
            Vector3 pointCamPos = targetCameraPoint.transform.position;
            pointCamPos.y += stepHeightPoint;
            targetCameraPoint.transform.position = pointCamPos;
        }
    }

    private void RemoveRow()
    {
        currentRow = Mathf.Max(--currentRow, 0);
        descRowText.text = "Ряд: " + (currentRow) + ". " + brikArray[Mathf.Max(currentRow-1, 0)].GetComponent<AddRow>().description;
        brikArray[currentRow].SetActive(false);

        if (currentRow > 0)
        {
            Vector3 pointCamPos = targetCameraPoint.transform.position;
            pointCamPos.y -= stepHeightPoint;
            targetCameraPoint.transform.position = pointCamPos;
        }
    }

    public void AddBtn()
    {
        AddRow(currentRow);
    }

    public void RemoveBtn()
    {
        RemoveRow();
    }



    void Update()
    {
        
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        pauseGame = false;
    }

    public void PauseMenuShow()
    {
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
        addBtn.SetActive(false);
        upBtn.SetActive(false);
        pauseGame = true;
    }

    public void ContinueScene()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        addBtn.SetActive(true);
        upBtn.SetActive(true);
        pauseGame = false;
    }

    public void LoadMainMenu()
    {
        pauseGame = true;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }


}
