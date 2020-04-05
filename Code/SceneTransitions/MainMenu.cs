/*
 * Script for the Main Menu. Holds all functions and variables realative to the Main Menu.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame() {
        SceneManager.LoadScene("Level-0");
    }

    public void Exit() {
        Debug.Log("quit");
        Application.Quit();
    }
}
