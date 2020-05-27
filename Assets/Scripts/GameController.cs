using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameControl;
    public GameObject pauseBtn;
    public GameObject pausePanel;
    public GameObject addBtn;
    public GameObject upBtn;

    public bool pauseGame = false;
    

    void Start()
    {
        gameControl = this;
        pausePanel.SetActive(false);

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
