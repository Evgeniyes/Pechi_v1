using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pauseBtn;
    public GameObject pausePanel;
    

    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        
    }

    public void PauseMenuShow()
    {
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
    }

    public void ContinueScene()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
    }


}
