/*
 * Script for the HealthPack. Holds all functions and variables realative to the health packs.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

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
        playerScript.PlayerHeal(20);
        Destroy(gameObject);
    }
}
