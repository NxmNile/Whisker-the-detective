using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEditorInternal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CluesInvestigate : MonoBehaviour
{
    [SerializeField] private GameObject investigateUI;
    [SerializeField] private GameObject DescriptionUI;
    [SerializeField] private GameObject BGPanel;
    [SerializeField] private TMP_Text guilde;
    [SerializeField] private TMP_Text descriptionTxt;
    [SerializeField] private Image descriptionImage;
    [SerializeField] private GameObject DesImage;
    [SerializeField] private Sprite[] images;
    [SerializeField] private GameObject[] cluesImage;
    [SerializeField] private GameObject[] Guides;
    private KeepData _keepData;
    private int i = 0;
    private int y = 0;
    private bool isInObjectCollider;
    private string gameObjectName;

    private void Start()
    {   
        _keepData = KeepData.Instance;
        if (_keepData != null)
        {
            Debug.Log(_keepData.sceneName);
        }
        else
        {
            Debug.LogError("KeepData is not assigned. Please assign it in the inspector.");
        }
    }


    void Update()
    {
        if (isInObjectCollider&&Input.GetKeyDown(KeyCode.F))
        {   
            //---------- World Scene-------------
            if (investigateUI != null)
            {
                investigateUI.SetActive(false);
            }
            if (_keepData.sceneName=="OwlHouse")
            {
                Guides[i].SetActive(false);
            }
            if (gameObjectName == "HouseDoor")
            {
                _keepData.sceneName = "OwlHouse";
                SceneManager.LoadScene("OwlHouse");
            }
            else if (gameObjectName == "PoliceStt")
            {
                if (_keepData.CheckAllClues())
                {
                    SceneManager.LoadScene("PoliceStation"); //unlock
                }
                else
                {
                    DescriptionUI.SetActive(true);
                    DesImage.SetActive(false);
                    descriptionTxt.text = "There are clues left. Please go back and investigate more.";
                    Time.timeScale = 0;
                }
                
            }
            else if(gameObjectName == "mainFoot")
            {   
                DescriptionUI.SetActive(true);
                DesImage.SetActive(true);
                descriptionTxt.text = "Muddy footprints near the shattered window match Maxie Badger's footprint";
                descriptionImage.sprite = images[0];//change number
                Time.timeScale = 0;
                _keepData.CluesList[0] = true;
            }
            else if (gameObjectName == "CCTV")
            {
                DescriptionUI.SetActive(true);
                DesImage.SetActive(true);
                descriptionTxt.text = "Security Camera Footage: Showing Bunny Alice entering the house late at night";
                descriptionImage.sprite = images[1];//change number
                Time.timeScale = 0;
                _keepData.CluesList[1] = true;
            }
            //--------------------------------------
            //----------Owl House-------------------
            if (gameObjectName == "glass5")
            {   
                DescriptionUI.SetActive(true);
                descriptionTxt.text = "A shattered window suggesting a possible break-in.";
                Time.timeScale = 0;
                _keepData.CluesList[2] = true;
            }
            else if(gameObjectName=="letter")
            {
                BGPanel.SetActive(true);
                DescriptionUI.SetActive(true);
                cluesImage[4].SetActive(true);
                y = 4;
                descriptionTxt.text = "A threatening letter addressed to Dr. Hootie found in the room's fireplace, partially burned.";
                Time.timeScale = 0;
                _keepData.CluesList[3] = true;
            }
            else if (gameObjectName == "WEAPON")
            {
                BGPanel.SetActive(true);
                DescriptionUI.SetActive(true);
                cluesImage[3].SetActive(true);
                y = 3;
                descriptionTxt.text =
                    "The murder weapon: An ancient artifact (a ceremonial dagger) from Dr. Hootie's collection, found wiped clean of fingerprints.";
                Time.timeScale = 0;
                _keepData.CluesList[4] = true;
            }
            else if (gameObjectName == "phone")
            {   
                BGPanel.SetActive(true);
                DescriptionUI.SetActive(true);
                cluesImage[2].SetActive(true);
                y = 2;
                descriptionTxt.text =
                    "Phone Records: Reveal multiple calls between Dr. Hootie and an unknown number, traced back to a burner phone found in Maxie's possession.";
                Time.timeScale = 0;
                _keepData.CluesList[5] = true;
            }
            else if (gameObjectName == "diary")
            {   
                BGPanel.SetActive(true);
                cluesImage[0].SetActive(true);
                DescriptionUI.SetActive(true);
                y = 0;
                descriptionTxt.text = "The Diary: The missing pages from the diary reveal Dr. Hootie was about to expose a significant fraud involving her husband and Maxie Badger.";
                Time.timeScale = 0;
                _keepData.CluesList[6] = true;
            }
            else if(gameObjectName=="bankRecord")
            {   
                BGPanel.SetActive(true);
                cluesImage[1].SetActive(true);
                y = 1;
                DescriptionUI.SetActive(true);
                descriptionTxt.text =
                    "Bank Records: Indicate Hawkin Owl withdrew a large sum of money shortly before Dr. Hootie's death.";
                Time.timeScale = 0;
                _keepData.CluesList[7] = true;
            }
            else if (gameObjectName=="Door")
            {
                _keepData.sceneName = "WorldMain";
                SceneManager.LoadScene("World 1");
            }
            ///////////////////////////////////////
            else
            {
                
            }
            isInObjectCollider = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        Debug.Log("Enter");
        isInObjectCollider = true;
        if (investigateUI != null)
        {
            investigateUI.SetActive(true);
        }
        gameObjectName = other.gameObject.name;
        //----------world scene------------
        if (gameObjectName == "HouseDoor"||gameObjectName=="PoliceStt")
        {
            guilde.text = "Enter";
        }
        else if (gameObjectName == "mainFoot"||gameObjectName=="CCTV")
        {
            guilde.text = "Investigate";
        }
        //--------------------------------------
        //----------Owl house-----------------
        if (gameObjectName == "diary")
        {
            Guides[1].SetActive(true);
            i = 1;
        }
        else if (gameObjectName == "phone")
        {
            Guides[2].SetActive(true);
            i = 2;
        }
        else if(gameObjectName=="bankRecord")
        {
            Guides[6].SetActive(true);
            i = 6;
        }
        
        else if (gameObjectName == "WEAPON")
        {
            Guides[4].SetActive(true);
            i = 4;
        }
        else if (gameObjectName == "letter")
        {
            Guides[3].SetActive(true);
            i = 3;
        }
        else if (gameObjectName == "Door")
        {
            Guides[7].SetActive(true);
            i = 7;
        }
        else if(gameObjectName=="glass5")
        {
            Guides[5].SetActive(true);
            i = 5 ;
        }
        //-----------------------------------
    }
    private void OnTriggerExit(Collider other)
    {   
        Debug.Log("Exit : "+gameObjectName);
        isInObjectCollider = false;
        if (investigateUI != null)
        {
            investigateUI.SetActive(false);
        }

        if (_keepData.sceneName=="OwlHouse")
        {
            Guides[i].SetActive(false);
        }
        
    }

    public void closeDescription()
    {
        Time.timeScale = 1;
        DescriptionUI.SetActive(false);
        if (BGPanel != null)
        {
            BGPanel.SetActive(false);
        }

        if (_keepData.sceneName=="OwlHouse")
        {
            cluesImage[y].SetActive(false);
        }
    }
}
