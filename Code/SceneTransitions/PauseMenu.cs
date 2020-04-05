/*
 * Script for the Pause menu. Holds all functions and variables realative to the Pause Menu.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;

    public GameObject pauseMenuUI;
	

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}
    /*
     * Functions below hold the code for each button in the pause menu
     * 
     */
    public void Resume()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void loadMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); 
    }

    public void Quit()
    {
        isPaused = false;
        Debug.Log("quit");
        Application.Quit();
    }
}
