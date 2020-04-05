/*
 * Script for the Level Selector. Holds all functions and variables realative to the Level Selection.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DropDown : MonoBehaviour {

    public void HandleInputData(int val)
    {
        switch (val)
        {
            case 0:
                SceneManager.LoadScene("Level-0"); // does nothign apparently
                break;
            case 1:
                SceneManager.LoadScene("Level-0");
                break;
            case 2:
                SceneManager.LoadScene("Level-1");
                break;
            case 3:
                SceneManager.LoadScene("Level-2");
                break;    
            case 4:
                SceneManager.LoadScene("Level-3");
                break;
            case 5:
                SceneManager.LoadScene("Level-4");
                break;
            case 6:
                SceneManager.LoadScene("Level-5");
                break;
            case 7:
                SceneManager.LoadScene("Level-6");
                break;
            case 8:
                SceneManager.LoadScene("Level-7");
                break;
        }
    }
}
