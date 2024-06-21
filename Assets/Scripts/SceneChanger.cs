using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private KeepData keepData;
    private void Start()
    {
        keepData = KeepData.Instance;
       
    }
    public void MainMenu()
    {   
        keepData.sceneName = "Introduction";
        SceneManager.LoadScene("Introduction");
    }

    public void IntroductionScene()
    {
        SceneManager.LoadScene("OwlHouse");
        keepData.sceneName = "OwlHouse";
    }
    
    public void TryAgain()
    {   
        keepData.CluesList = new []{false,false,false,false,false,false,false,false};
        keepData.dialogList = new[] { false, false, false, false };
        IntroductionScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
