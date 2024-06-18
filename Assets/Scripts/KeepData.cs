using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepData
{   
    private static KeepData _instance;

    public static KeepData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new KeepData();
            }
            return _instance;
        }
    }

    public bool[] CluesList = new []{false,false,false,false,false,false,false,false};
    public string sceneName ="";

    public bool CheckAllClues()
    {
        int count = 0;
        for (int i = 0; i < CluesList.Length; i++)
        {
            if (CluesList[i] == true)
            {
                ++count;
            }
        }
        if (count == 8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
