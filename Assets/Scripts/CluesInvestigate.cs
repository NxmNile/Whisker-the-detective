using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CluesInvestigate : MonoBehaviour
{
    [SerializeField] private GameObject investigateUI;
    [SerializeField] private GameObject DescriptionUI;
    [SerializeField] private TMP_Text guilde;
    [SerializeField] private TMP_Text descriptionTxt;
    [SerializeField] private Image descriptionImage;
    [SerializeField] private Sprite[] images;
    [SerializeField] private GameObject[] cluesImage;
    private bool isInObjectCollider;
    private string gameObjectName;
    void Update()
    {
        if (isInObjectCollider&&Input.GetKeyDown(KeyCode.F))
        {   
            //---------- World Scene-------------
            investigateUI.SetActive(false);
            if (gameObjectName == "HouseDoor")
            {   
                SceneManager.LoadScene("OwlHouse");
            }
            else if (gameObjectName == "PoliceStt")
            {
                SceneManager.LoadScene("PoliceStation");
            }
            else if(gameObjectName == "mainFoot")
            {
                DescriptionUI.SetActive(true);
                descriptionTxt.text = "Muddy footprints near the shattered window match Maxie Badger's footprint";
                descriptionImage.sprite = images[0];//change number
                Time.timeScale = 0;
            }
            else if (gameObjectName == "CCTV")
            {
                DescriptionUI.SetActive(true);
                descriptionTxt.text = "Security Camera Footage: Showing Bunny Alice entering the house late at night";
                descriptionImage.sprite = images[1];//change number
                Time.timeScale = 0;
            }
            //--------------------------------------
            //----------Owl House-------------------
            
            ///////////////////////////////////////
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        Debug.Log("Enter");
        isInObjectCollider = true;
        investigateUI.SetActive(true);
        gameObjectName = other.gameObject.name;
        //----------world scene------------
        if (other.gameObject.name == "HouseDoor")
        {
            guilde.text = "Enter";
        }
        else if (other.gameObject.name == "PoliceStt")
        {
            guilde.text = "Enter";
        }
        else if (other.gameObject.name == "mainFoot")
        {
            guilde.text = "Investigate";
        }
        else if (other.gameObject.name == "CCTV")
        {
            guilde.text = "Investigate";
        }
        //--------------------------------------
    }
    private void OnTriggerExit(Collider other)
    {
        isInObjectCollider = false;
        investigateUI.SetActive(false);
        Debug.Log(other.gameObject.name);
    }

    public void closeDescription()
    {
        Time.timeScale = 1;
        DescriptionUI.SetActive(false);
    }
}
