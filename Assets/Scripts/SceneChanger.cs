using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private KeepData keepData;
    public void MainMenu()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void IntroductionScene()
    {
        SceneManager.LoadScene("OwlHouse");
        keepData.sceneName = "OwlHouse";
    }
}
