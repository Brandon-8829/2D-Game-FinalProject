using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

    private int nextScene;
    

    // Use this for initialization
    void Start()
    {  
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;//change 'randomIndex' to 1 if you want to increment each level. Vice Versa if you want to have a random level.
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Menu");
    }
}
