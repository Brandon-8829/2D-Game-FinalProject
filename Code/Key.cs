/*
 * Script for the key(orb). Holds all functions and variables realative to the key.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public Player playerScript;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        playerScript.KeyGained();
        Destroy(gameObject);
    }
}
