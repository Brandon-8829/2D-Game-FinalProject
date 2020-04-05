//updates text on the screen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyTextUpdate : MonoBehaviour {

    public Player playerScript;
    public TextMeshProUGUI text;


    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    //accesing the fixed update loop...there are many update loops in unity.
    void Update()
    {
        text.SetText("KEYS: " + playerScript.keyCount);
    }
}
