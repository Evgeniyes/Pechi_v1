using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadScenePech1()
    {
        SceneManager.LoadScene("Pech1", LoadSceneMode.Single);
    }
}
