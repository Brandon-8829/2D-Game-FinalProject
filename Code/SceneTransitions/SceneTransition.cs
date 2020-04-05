/*
 * Script for the Scene Transitions. Holds all functions and variables realative to the Scene Transitions.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour {

    private int nextScene;
    public Player playerScript;

    System.Random rnd = new System.Random();

	// Use this for initialization
	void Start () {
        int randomIndex = rnd.Next(1, 5);
        nextScene = SceneManager.GetActiveScene().buildIndex + 1; //change 'randomIndex' to 1 if you want to increment each level. Vice Versa if you want to have a random level.
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && playerScript.keyCount == 1)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
